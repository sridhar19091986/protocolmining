namespace AutoUpdater
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    public class UpdateFrame : Form
    {
        private int availableUpdate;
        private BackgroundWorker bgWorker;
        private Button btnCancel;
        private IContainer components;
        private string extParams = "";
        private string finalSrcUpdateListFile = "";
        private string finalTarUpdateListFile = "";
        private Label lbNotice;
        private Label lbSubNotice;
        private string mainAppExe = "";
        private PictureBox pictureBox1;
        private ProgressBar progBarMain;
        private ProgressBar progBarSub;
        private string tempUpdatePath = string.Empty;
        private XmlFiles updaterXmlFiles;
        private string updateUrl = string.Empty;

        public UpdateFrame(string[] Args)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in Args)
            {
                builder.Append(str);
                builder.Append(" ");
            }
            this.extParams = builder.ToString();
            this.InitializeComponent();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.docheckUpdate(e);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ProcShow)
            {
                ProcShow userState = e.UserState as ProcShow;
                this.progBarMain.Value = userState.mainV;
                this.progBarSub.Value = userState.subV;
                this.lbNotice.Text = userState.labelShow;
                this.lbSubNotice.Text = userState.logShow;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.bgWorker.CancelAsync();
            this.doStartMainProc();
            Application.Exit();
        }

        private bool closeMainProg()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if ((process.ProcessName.ToLower() + ".exe") == this.mainAppExe.ToLower())
                {
                    if (DialogResult.OK != MessageBox.Show("程序已经被打开，是否关闭？", "软件升级", MessageBoxButtons.OKCancel))
                    {
                        return false;
                    }
                    for (int i = 0; i < process.Threads.Count; i++)
                    {
                        process.Threads[i].Dispose();
                    }
                    process.Kill();
                }
            }
            return true;
        }

        public void CopyFile(string sourcePath, string objPath)
        {
            if (!Directory.Exists(objPath))
            {
                Directory.CreateDirectory(objPath);
            }
            string[] files = Directory.GetFiles(sourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] strArray2 = files[i].Split(new char[] { '\\' });
                if (files[i].IndexOf("UpdateList.xml") == -1)
                {
                    this.CopyFileItem(files[i], objPath + @"\" + strArray2[strArray2.Length - 1]);
                }
                else
                {
                    this.finalSrcUpdateListFile = files[i];
                    this.finalTarUpdateListFile = objPath + @"\" + strArray2[strArray2.Length - 1];
                }
            }
            string[] directories = Directory.GetDirectories(sourcePath);
            for (int j = 0; j < directories.Length; j++)
            {
                string[] strArray4 = directories[j].Split(new char[] { '\\' });
                this.CopyFile(directories[j], objPath + @"\" + strArray4[strArray4.Length - 1]);
            }
        }

        private void CopyFileItem(string source, string dest)
        {
            int num;
            FileStream stream = new FileStream(source, FileMode.Open);
            FileStream stream2 = new FileStream(dest, FileMode.Create);
            while ((num = stream.ReadByte()) != -1)
            {
                stream2.WriteByte((byte) num);
            }
            stream.Close();
            stream2.Close();
        }

        private void CreateDirtory(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                string[] strArray = path.Split(new char[] { '\\' });
                string str = string.Empty;
                for (int i = 0; i < (strArray.Length - 1); i++)
                {
                    str = str + strArray[i].Trim() + @"\";
                    if (!Directory.Exists(str))
                    {
                        Directory.CreateDirectory(str);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void docheckUpdate(DoWorkEventArgs e)
        {
            string xmlFile = Application.StartupPath + @"\UpdateList.xml";
            string serverXmlFile = string.Empty;
            try
            {
                this.updaterXmlFiles = new XmlFiles(xmlFile);
                this.mainAppExe = this.updaterXmlFiles.GetNodeValue("//EntryPoint");
            }
            catch
            {
                MessageBox.Show("配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
                return;
            }
            this.updateUrl = this.updaterXmlFiles.GetNodeValue("//Url");
            AppUpdater updater = new AppUpdater();
            updater.UpdaterUrl = this.updateUrl + "/UpdateList.xml";
            this.bgWorker.ReportProgress(0, new ProcShow(0, 0, "尝试与服务器进行连接...", ""));
            this.tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + @"\_" + this.updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + @"_update_\";
            if (updater.DownAutoUpdateFile(this.tempUpdatePath))
            {
                this.bgWorker.ReportProgress(0, new ProcShow(0, 0, "连接成功，检测需要更新的文件...", ""));
                Hashtable updateFileList = new Hashtable();
                serverXmlFile = this.tempUpdatePath + @"\UpdateList.xml";
                this.availableUpdate = updater.CheckForUpdate(serverXmlFile, xmlFile, out updateFileList);
                if (this.availableUpdate > 0)
                {
                    this.bgWorker.ReportProgress(0, new ProcShow(0, 0, "检测到" + this.availableUpdate + "个待更新文件!", ""));
                    if (this.closeMainProg())
                    {
                        if (this.downloadUpdatedFiles(updateFileList, e))
                        {
                            this.FinishCopyAllFiles();
                            this.doStartMainProc();
                            Application.Exit();
                        }
                        else
                        {
                            this.doStartMainProc();
                            Application.Exit();
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    this.bgWorker.ReportProgress(0, new ProcShow(0, 0, "未检测到更新!", ""));
                    this.doStartMainProc();
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("获取远程配置信息失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.doStartMainProc();
                Application.Exit();
            }
        }

        private void doStartMainProc()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = this.mainAppExe;
                startInfo.Arguments = this.extParams;
                startInfo.WorkingDirectory = Application.StartupPath + @"\";
                Process.Start(startInfo);
            }
            catch
            {
                MessageBox.Show("启动程序失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private bool downloadUpdatedFiles(Hashtable htUpdateFile, DoWorkEventArgs e)
        {
            if (htUpdateFile.Count != 0)
            {
                new WebClient();
                for (int i = 0; i < htUpdateFile.Count; i++)
                {
                    string[] strArray = (string[]) htUpdateFile[i];
                    string str = strArray[0].Trim();
                    string requestUriString = this.updateUrl + str;
                    long contentLength = 0L;
                    try
                    {
                        WebResponse response = WebRequest.Create(requestUriString).GetResponse();
                        contentLength = response.ContentLength;
                        int mainv = (100 * i) / (htUpdateFile.Count + 1);
                        ProcShow userState = new ProcShow(mainv, 0, "还有" + ((htUpdateFile.Count - i) - 1) + "个文件待下载!", string.Concat(new object[] { "下载第", i + 1, "个文件:", str }));
                        this.bgWorker.ReportProgress(0, userState);
                        Stream responseStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responseStream);
                        byte[] buffer = new byte[contentLength];
                        int length = buffer.Length;
                        int offset = 0;
                        while (length > 0)
                        {
                            int num6 = responseStream.Read(buffer, offset, length);
                            if (num6 == 0)
                            {
                                break;
                            }
                            offset += num6;
                            length -= num6;
                            float num7 = ((float) offset) / 1024f;
                            float num8 = ((float) buffer.Length) / 1024f;
                            int num9 = Convert.ToInt32((float) ((num7 / num8) * 100f));
                            userState.subV = num9;
                            this.bgWorker.ReportProgress(0, userState);
                        }
                        string path = this.tempUpdatePath + str;
                        this.CreateDirtory(path);
                        FileStream stream2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        stream2.Write(buffer, 0, buffer.Length);
                        responseStream.Close();
                        reader.Close();
                        stream2.Close();
                        if (this.bgWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return false;
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("更新文件下载失败！" + exception.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
            }
            return true;
        }

        private void FinishCopyAllFiles()
        {
            this.bgWorker.ReportProgress(0, new ProcShow(100, 100, "正在替换更新文件，请稍候...", "下载完毕!"));
            try
            {
                this.CopyFile(this.tempUpdatePath, Directory.GetCurrentDirectory());
                this.CopyFileItem(this.finalSrcUpdateListFile, this.finalTarUpdateListFile);
                Directory.Delete(this.tempUpdatePath, true);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(UpdateFrame));
            this.pictureBox1 = new PictureBox();
            this.lbNotice = new Label();
            this.progBarSub = new ProgressBar();
            this.btnCancel = new Button();
            this.progBarMain = new ProgressBar();
            this.lbSubNotice = new Label();
            this.bgWorker = new BackgroundWorker();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.pictureBox1.Dock = DockStyle.Top;
            this.pictureBox1.Image = (Image) manager.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x184, 0x51);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.lbNotice.BackColor = Color.Transparent;
            this.lbNotice.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.lbNotice.Location = new Point(10, 0x54);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new Size(0x17f, 13);
            this.lbNotice.TabIndex = 1;
            this.lbNotice.Text = "正在检测更新...";
            this.progBarSub.Location = new Point(12, 0x8a);
            this.progBarSub.Name = "progBarSub";
            this.progBarSub.Size = new Size(0x16f, 12);
            this.progBarSub.Step = 1;
            this.progBarSub.Style = ProgressBarStyle.Continuous;
            this.progBarSub.TabIndex = 3;
            this.btnCancel.Location = new Point(0x14e, 0x9c);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x2d, 0x17);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "忽略";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.progBarMain.Location = new Point(12, 100);
            this.progBarMain.Name = "progBarMain";
            this.progBarMain.Size = new Size(0x16f, 12);
            this.progBarMain.Step = 1;
            this.progBarMain.Style = ProgressBarStyle.Continuous;
            this.progBarMain.TabIndex = 3;
            this.lbSubNotice.BackColor = Color.Transparent;
            this.lbSubNotice.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.lbSubNotice.Location = new Point(10, 0x7a);
            this.lbSubNotice.Name = "lbSubNotice";
            this.lbSubNotice.Size = new Size(0x17f, 13);
            this.lbSubNotice.TabIndex = 1;
            this.lbSubNotice.Text = "更新文件进度...";
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            this.bgWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = SystemColors.Control;
            base.ClientSize = new Size(0x184, 0xb8);
            base.ControlBox = false;
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.progBarMain);
            base.Controls.Add(this.progBarSub);
            base.Controls.Add(this.lbSubNotice);
            base.Controls.Add(this.lbNotice);
            base.Controls.Add(this.pictureBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "UpdateFrame";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "检测版本更新";
            base.Shown += new EventHandler(this.UpdateFrame_Shown);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        private void UpdateFrame_Shown(object sender, EventArgs e)
        {
            this.bgWorker.RunWorkerAsync();
        }
    }
}

