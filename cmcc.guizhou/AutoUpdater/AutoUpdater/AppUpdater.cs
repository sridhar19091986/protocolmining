namespace AutoUpdater
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Xml;
    using System.Diagnostics;

    public class AppUpdater : IDisposable
    {
        private string _updaterUrl;
        private Component component = new Component();
        private bool disposed;
        private IntPtr handle;

        public int CheckForUpdate()
        {
            string path = Application.StartupPath + @"\UpdateList.xml";
            if (!System.IO.File.Exists(path))
            {
                return -1;
            }
            XmlFiles files = new XmlFiles(path);
            string downpath = Environment.GetEnvironmentVariable("Temp") + @"\_" + files.FindNode("//Application").Attributes["applicationId"].Value + @"_y_x_m_\";
            this.UpdaterUrl = files.GetNodeValue("//Url") + "/UpdateList.xml";
            this.DownAutoUpdateFile(downpath);
            string str3 = downpath + @"\UpdateList.xml";
            if (!System.IO.File.Exists(str3))
            {
                return -1;
            }
            XmlFiles files2 = new XmlFiles(str3);
            XmlFiles files3 = new XmlFiles(path);
            XmlNodeList nodeList = files2.GetNodeList("AutoUpdater/Files");
            XmlNodeList list2 = files3.GetNodeList("AutoUpdater/Files");
            int num = 0;
            for (int i = 0; i < nodeList.Count; i++)
            {
                string[] strArray = new string[3];
                string str4 = nodeList.Item(i).Attributes["Name"].Value.Trim();
                string str5 = nodeList.Item(i).Attributes["Ver"].Value.Trim();
                ArrayList list3 = new ArrayList();
                for (int j = 0; j < list2.Count; j++)
                {
                    string str6 = list2.Item(j).Attributes["Name"].Value.Trim();
                    string str7 = list2.Item(j).Attributes["Ver"].Value.Trim();
                    list3.Add(str6);
                    list3.Add(str7);
                }
                int index = list3.IndexOf(str4);
                if (index == -1)
                {
                    strArray[0] = str4;
                    strArray[1] = str5;
                    num++;
                }
                else if ((index > -1) && (str5.CompareTo(list3[index + 1].ToString()) > 0))
                {
                    strArray[0] = str4;
                    strArray[1] = str5;
                    num++;
                }
            }
            return num;
        }

        public int CheckForUpdate(string serverXmlFile, string localXmlFile, out Hashtable updateFileList)
        {
            updateFileList = new Hashtable();
            if (!System.IO.File.Exists(localXmlFile) || !System.IO.File.Exists(serverXmlFile))
            {
                return -1;
            }
            XmlFiles files = new XmlFiles(serverXmlFile);
            XmlFiles files2 = new XmlFiles(localXmlFile);
            XmlNodeList nodeList = files.GetNodeList("AutoUpdater/Files");
            XmlNodeList list2 = files2.GetNodeList("AutoUpdater/Files");
            int key = 0;
            for (int i = 0; i < nodeList.Count; i++)
            {
                string[] strArray = new string[3];
                string str = nodeList.Item(i).Attributes["Name"].Value.Trim();
                string str2 = nodeList.Item(i).Attributes["Ver"].Value.Trim();
                ArrayList list3 = new ArrayList();
                for (int j = 0; j < list2.Count; j++)
                {
                    string str3 = list2.Item(j).Attributes["Name"].Value.Trim();
                    string str4 = list2.Item(j).Attributes["Ver"].Value.Trim();
                    list3.Add(str3);
                    list3.Add(str4);
                }
                int index = list3.IndexOf(str);
                if (index == -1)
                {
                    strArray[0] = str;
                    strArray[1] = str2;
                    updateFileList.Add(key, strArray);
                    key++;
                }
                else if ((index > -1) && (str2.CompareTo(list3[index + 1].ToString()) > 0))
                {
                    strArray[0] = str;
                    strArray[1] = str2;
                    updateFileList.Add(key, strArray);
                    key++;
                }
            }
            return key;
        }

        [DllImport("Kernel32")]
        private static extern bool CloseHandle(IntPtr handle);
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.component.Dispose();
                }
                CloseHandle(this.handle);
                this.handle = IntPtr.Zero;
            }
            this.disposed = true;
        }

        public bool DownAutoUpdateFile(string downpath)
        {
            if (!Directory.Exists(downpath))
            {
                Directory.CreateDirectory(downpath);
            }
            //string fileName = downpath + "/UpdateList.xml";

            string fileName =  "UpdateList.xml";
            //try
            //{
            //if (WebRequest.Create(this.UpdaterUrl).GetResponse().ContentLength > 0L)
            //{
            //try
            //{
            //WebRequest.Create(this.UpdaterUrl).GetResponse();
            //new WebClient().DownloadFile(this.UpdaterUrl, fileName);

            DownLoadFile(this.UpdaterUrl, fileName);
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
            //}
            ////}
            //catch
            //{
            //    return false;
            //}
            //else
            //    return false;
        }

        ~AppUpdater()
        {
            this.Dispose(false);
        }

        public string UpdaterUrl
        {
            get
            {
                return this._updaterUrl;
            }
            set
            {
                this._updaterUrl = value;
            }
        }
        private void DownLoadFile(string url,string filename)
        {
            //try
            //{

                ProcessStartInfo psi = new ProcessStartInfo("cmd");
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                psi.UseShellExecute = false;
                Process p = Process.Start(psi);
                p.StandardInput.WriteLine(@"chdir /d  D:\Program Files\TortoiseSVN\bin");
                //更新(下载)服务器上的最新版本       
                //p.StandardInput.WriteLine("svn  update " + filename);
                //svn checkout <url_of_big_dir> <target> --depth empty
                //cd <target>
                //svn up <file_you_want>
                p.StandardInput.WriteLine("svn checkout " + url + " ttt");
                p.StandardInput.WriteLine("cd ttt");
                p.StandardInput.WriteLine("svn up " + filename);
                //p.StandardInput.WriteLine(@"exit");
                //p.WaitForExit();
                //p.Close();

            //}
            //catch { }
        }
    }
}

