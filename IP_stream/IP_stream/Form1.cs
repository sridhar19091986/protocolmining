﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Reflection;
using System.Collections;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading.Tasks;
using connStringConfig;
using streamTypeDefine;
using Altova.Types;
using IP_stream.AsynchThread;

namespace IP_stream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0) return;

            DialogResult dlgResult = MessageBox.Show("Do you want to continue Access Remote Database ?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
                switch (e.Node.Name)
                {
                    case "ImportCiData":
                        ImportCiData();
                        break;
                    case "BulkExcute":
                        BulkExcute();
                        MessageBox.Show("OK");
                        break;
                    case "OutPutPDCH":
                        OutPutTable t = new OutPutTable();
                        dataGridView1.DataSource = t.CiPDCH;
                        MessageBox.Show("OK");
                        break;

                    default:
                        QueryTable(e.Node.Text);
                        break;
                }
        }
        private void BulkExcute()
        {
            DualTests dt = new DualTests();
            dt.Show();dt.Focus();
            handleTable h = new handleTable();
            //case "AlterPrimaryKey":
            toolStripStatusLabel1.Text = h.AlterPrimaryKey();
            //case"InitImeiCiTypeTable":
            toolStripStatusLabel1.Text = h.InitImeiCiTypeTable();
            //case"InitMlocationTable":
            toolStripStatusLabel1.Text = h.InitMlocationTable();
            //case"InsertImeiType":
            imeiTypeClass _imeiTypeClass = new imeiTypeClass(true);
            //Parallel.For(0, 2, i => { MessageBox.Show(i.ToString()); });
            Parallel.For(0, 2, i => { _imeiTypeClass.InsertImeiType(_imeiTypeClass, i); });
            Thread.Sleep(1); GC.Collect(); Application.DoEvents();
            Parallel.For(2, 4, i => { _imeiTypeClass.InsertImeiType(_imeiTypeClass, i); });
            QueryTable("msIMEI");
            //case"InsertCiType":
            ciType _ciType = new ciType(true);
            Task t1 = new Task(() => { _ciType.InsertCiType(_ciType, 0); }); t1.Start();
            QueryTable("ciBVCI");
            //case"UpdateImeiType":
            imeiTypeClass _imeiTypeClass_false = new imeiTypeClass(false);
            Task t2 = new Task(() => { _imeiTypeClass_false.UpdateImeiType(); }); t2.Start();
            QueryTable("msIMEI");
            //case"InsertResultTable":
            mLocatingConvert ml = new mLocatingConvert();
            Parallel.For(0, 2, i => { ml.SendOrders(ml, i); });
            Thread.Sleep(1); GC.Collect(); Application.DoEvents();
            Parallel.For(0, 4, i => { ml.SendOrders(ml, i); });
            dt.Close();
        }
        private void QueryTable(string tbName)
        {
            //只有IP_stream不在本地
            try
            {
                if (tbName == "ciCoverType" || tbName == "imeiType")
                    using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
                    {
                        dataGridView1.DataSource = mess.GetTableByName(tbName);
                        toolStripStatusLabel1.Text = mess.Connection.ConnectionString;
                    }
                else
                {
                    //DialogResult dlgResult = MessageBox.Show("Do you want to continue Access Remote Database ?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (dlgResult == DialogResult.Yes && tbName != "OutPutPDCH")
                        using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.RemoteConnString))
                        {
                            dataGridView1.DataSource = mess.GetTableByName(tbName);
                            toolStripStatusLabel1.Text = mess.Connection.ConnectionString;
                        }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ImportCiData()
        {
            OpenFileDialog dlgOpenfile = new OpenFileDialog();
            string strFileFullName = null;
            dlgOpenfile.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            dlgOpenfile.Title = "Open";
            dlgOpenfile.ShowDialog();
            dlgOpenfile.RestoreDirectory = true;
            if (!string.IsNullOrEmpty(dlgOpenfile.FileName))
                strFileFullName = dlgOpenfile.FileName;
            ciPdchBulk(strFileFullName);


            string stattime = InputBox("OSS和Gb的时间匹配", "请选定Gb采集时间", "16/02/2011 09:00:00");

            ciCoverType(stattime);

        }
   
        private void ciPdchBulk(string csvfile)
        {

            string dropsql = @"  IF  EXISTS (SELECT * FROM sys.objects 
                                WHERE object_id = OBJECT_ID(N'[dbo].[ciPdchBulk]') AND type in (N'U'))
                                DROP TABLE [dbo].[ciPdchBulk]";
            string createsql = @" 
                                CREATE TABLE ciPdchBulk
                                ( 
                                    lac  VARCHAR(32) null,
                                    ci  VARCHAR(32) null,
                                    stat_time  VARCHAR(32) null,
                                    ci_name VARCHAR(32) null,
                                    available_pdch VARCHAR(32) null,
                                    use_pdch VARCHAR(32) null,
                                    assignment_pdch_rate VARCHAR(32) null,
                                )";

            string insertsql = @" BULK INSERT ciPdchBulk
                                    FROM '"+csvfile+"'  WITH ( FIRSTROW = 2,FIELDTERMINATOR = ',', ROWTERMINATOR = '\n'  )";
            DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString);
            mess.ExecuteCommand(dropsql);
            mess.ExecuteCommand(createsql);
            mess.ExecuteCommand(insertsql);
            MessageBox.Show("OK");
        }
        private void ciCoverType(string stattime)
        {
            string createsql = @" IF  EXISTS (SELECT * FROM sys.objects 
                                WHERE object_id = OBJECT_ID(N'[dbo].[ciCoverType]') AND type in (N'U'))
                                DROP TABLE [dbo].[ciCoverType]";
            string insertsql = @" SELECT IDENTITY(int, 1,1) AS ciCoverType_id,* into ciCoverType
                                from (select lac+'-'+ci as lacCI,ci_name as ciName,
                                available_pdch as ciCoverModel,use_pdch as ciCoverClass
                                from dbo.ciPdchBulk
                                where stat_time='" + stattime + "') as a";
            DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString);
            mess.ExecuteCommand(createsql);
            mess.ExecuteCommand(insertsql);
            MessageBox.Show("OK");
            QueryTable("ciCoverType");
        }



        private void DisplayResultTable()
        {
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
                dataGridView1.DataSource = mess.mLocatingType;
        }

        private void DisplayOrignalTable()
        {
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
                dataGridView1.DataSource = mess.IP_stream;
        }
        /*
    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs c)
    {
        
        XElement dataConfig = XElement.Load(streamType.configXmlPath);
        foreach (var q1 in dataConfig.Elements("connectionStrings"))
            if (q1.Element("connectionString").Value == a)
                b = a;
        if (b == null)
            b = appConfig.GetConnectionStringsConfig("IP_stream.Properties.Settings.IP_StreamConnectionString");
         * 
             
        //checkedListBox1.GetItemText(checkedListBox1.SelectedItem);

    }
    * */


        private void refreshTreeViewGetTables()
        {
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
            {
                TreeNode tn = new TreeNode(mess.Connection.DataSource + "_" + mess.Connection.Database);
                foreach (var t in mess.Mapping.GetTables())
                    tn.Nodes.Add(t.TableName.Substring(4));
                treeView1.Nodes.Add(tn);
            }
            treeView1.ExpandAll();
        }
        private void refreshTreeViewstreamType()
        {
            XElement dataConfig2 = XElement.Load(streamType.streamTypeXmlPath);
            var query0 = dataConfig2.Elements();
            foreach (var q0 in query0)
            {
                TreeNode tn0 = new TreeNode(q0.Name.LocalName);
                var query1 = query0.Where(e => e.Name == q0.Name).Elements();
                foreach (var q1 in query1)
                {
                    TreeNode tn1 = new TreeNode(q1.Attribute("name").Value);
                    tn0.Nodes.Add(tn1);
                    var query2 = query1.Where(e => e.Attribute("name").Value == q1.Attribute("name").Value).Elements();
                    foreach (var q2 in query2)
                    {
                        TreeNode tn2 = new TreeNode(q2.Value);
                        tn1.Nodes.Add(tn2);
                    }
                }
                treeViewAnalysis.Nodes.Add(tn0);
            }
            treeViewAnalysis.ExpandAll();
        }
        private void Form1_Load(object sender, EventArgs c)
        {
            /*
            #region   远程数据库，取xml文件中第一个连接
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            XElement mod = dataConfig.Elements("connectionStrings").ElementAt(0);
            streamType.RemoteConnString = mod.Element("connectionString").Value;
            toolStripStatusLabel2.Text = streamType.RemoteConnString;
            #endregion
          

            #region   远程数据库，取xml文件中<configSections>中的连接
            connStringConfig.connStringConfig2 doc = connStringConfig.connStringConfig2.LoadFromFile(streamType.configXmlPath);
            connStringConfig.configurationType level1 = doc.configuration.First;
            connStringConfig.configSectionsType level2 = level1.configSections.First;
            streamType.RemoteConnString = level2.add.First.connectionString.Value;
            toolStripStatusLabel2.Text = streamType.RemoteConnString;
            #endregion
             * 
             *    * 
             * */



            refreshTreeViewConn();
            refreshTreeViewGetTables();
            refreshTreeViewstreamType();

            //streamType.RemoteConnString = streamType.RemoteConnString;
        }

        private void hiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
        }

        # region linq xml  will remove code
        private void modifyConnStringToolStripMenuItem_Click(object sender, EventArgs args)
        {
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            // string rem = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
            string rem = treeViewConn.SelectedNode.Text;
            XElement mod = dataConfig.Elements("connectionStrings").Where(e => e.Element("connectionString").Value == rem).First();
            mod.Element("connectionString").Value = richTextBox1.Text;
            mod.Element("DateTime").Value = System.DateTime.Now.ToString();
            dataConfig.Save(streamType.configXmlPath);
            refreshTreeViewConn();
        }

        private void addConnStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            XElement addx = new XElement("connectionStrings",
            new XElement("connectionString", richTextBox1.Text),
            new XElement("DateTime", System.DateTime.Now));
            dataConfig.Add(addx);
            dataConfig.Save(streamType.configXmlPath);
            refreshTreeViewConn();
        }

        private void deleteConnStringToolStripMenuItem_Click(object sender, EventArgs args)
        {
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            //string rem = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
            string rem = treeViewConn.SelectedNode.Text;
            dataConfig.Elements("connectionStrings").Where(e => e.Element("connectionString").Value == rem).First().Remove();
            dataConfig.Save(streamType.configXmlPath);
            refreshTreeViewConn();
        }

        #endregion

        #region  treeView3   treeViewConn 控件 添加、删除、重命名、上移、下移节点
        private void treeView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStripConn.Show(this, new Point(e.X, e.Y));
        }

        private void addConnectionNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode nod = new TreeNode("new Name");
            treeViewConn.SelectedNode.Nodes.Add(nod);
            treeViewConn.SelectedNode.ExpandAll();

            string selectnodeparenttext = selectNode.Parent.Text;
            connStringConfig.connStringConfig2 doc = connStringConfig.connStringConfig2.LoadFromFile(streamType.configXmlPath);
            connStringConfig.configurationType level1 = doc.configuration.First;
            connStringConfig.LocalDatabaseConnType localX = level1.LocalDatabaseConn.First;
            connStringConfig.RemoteDatabaseConnType remoteX = level1.RemoteDatabaseConn.First;
            connStringConfig.InsertDatabaseConnType insertX = level1.InsertDatabaseConn.First;
            connStringConfig.DatabaseConnPoolType poolX = level1.DatabaseConnPool.First;

            switch (selectnodeparenttext)
            {
                case "LocalDatabaseConn":
                    connStringConfig.addType local = localX.add.Append();
                    local.connectionString.Value = "new Name";
                    local.name.Value = "new Name";
                    break;
                case "RemoteDatabaseConn":
                    connStringConfig.addType remote = remoteX.add.Append();
                    remote.connectionString.Value = "new Name";
                    remote.name.Value = "new Name";
                    break;
                case "InsertDatabaseConn":
                    connStringConfig.addType insert = insertX.add.Append();
                    insert.connectionString.Value = "new Name";
                    insert.name.Value = "new Name";
                    break;
                case "DatabaseConnPool":
                    connStringConfig.addType pool = poolX.add.Append();
                    pool.connectionString.Value = "new Name";
                    pool.name.Value = "new Name";
                    break;
                default:
                    break;
            }
            doc.SaveToFile(streamType.configXmlPath, true);
            //SaveTreeViewConn();
        }

        private void deleteConnectionNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string deletenodetext = selectNode.Text;
            string selectnodeparenttext = selectNode.Parent.Text;

            //判断选定的节点是否存在下一级节点 
            if (treeViewConn.SelectedNode.Nodes.Count == 0)
                //删除节点
                treeViewConn.SelectedNode.Remove();
            else
                MessageBox.Show("请先删除此节点中的子节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            connStringConfig.connStringConfig2 doc = connStringConfig.connStringConfig2.LoadFromFile(streamType.configXmlPath);
            connStringConfig.configurationType level1 = doc.configuration.First;
            connStringConfig.LocalDatabaseConnType localX = level1.LocalDatabaseConn.First;
            connStringConfig.RemoteDatabaseConnType remoteX = level1.RemoteDatabaseConn.First;
            connStringConfig.InsertDatabaseConnType insertX = level1.InsertDatabaseConn.First;
            connStringConfig.DatabaseConnPoolType poolX = level1.DatabaseConnPool.First;

            switch (selectnodeparenttext)
            {
                case "LocalDatabaseConn":
                    for (int i = 0; i < localX.add.Count; i++)
                        if (localX.add.At(i).name.Value == deletenodetext)
                            localX.add.RemoveAt(i);
                    break;
                case "RemoteDatabaseConn":
                    for (int i = 0; i < remoteX.add.Count; i++)
                        if (remoteX.add.At(i).name.Value == deletenodetext)
                            remoteX.add.RemoveAt(i);
                    break;
                case "InsertDatabaseConn":
                    for (int i = 0; i < insertX.add.Count; i++)
                        if (insertX.add.At(i).name.Value == deletenodetext)
                            insertX.add.RemoveAt(i);
                    break;
                case "DatabaseConnPool":
                    for (int i = 0; i < poolX.add.Count; i++)
                        if (poolX.add.At(i).name.Value == deletenodetext)
                            poolX.add.RemoveAt(i);
                    break;
                default:
                    break;
            }

            doc.SaveToFile(streamType.configXmlPath, true);
        }

        private void modifyConnectionNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //treeViewConn.LabelEdit = true;
            //treeViewConn.SelectedNode.BeginEdit();
            if (selectNode.Level == 0) return;
            string modifynodetext = selectNode.Text;
            string selectnodeparenttext = selectNode.Parent.Text;

            connStringConfig.connStringConfig2 doc = connStringConfig.connStringConfig2.LoadFromFile(streamType.configXmlPath);
            connStringConfig.configurationType level1 = doc.configuration.First;
            connStringConfig.LocalDatabaseConnType localX = level1.LocalDatabaseConn.First;
            connStringConfig.RemoteDatabaseConnType remoteX = level1.RemoteDatabaseConn.First;
            connStringConfig.InsertDatabaseConnType insertX = level1.InsertDatabaseConn.First;
            connStringConfig.DatabaseConnPoolType poolX = level1.DatabaseConnPool.First;

            switch (selectnodeparenttext)
            {
                case "LocalDatabaseConn":
                    for (int i = 0; i < localX.add.Count; i++)
                        if (localX.add.At(i).name.Value == modifynodetext)
                        {
                            connStringConfig.addType local = localX.add.At(i);
                            local.name.Value = "new Name1";
                            local.connectionString.Value = richTextBox1.Text;
                        }
                    break;
                case "RemoteDatabaseConn":
                    for (int i = 0; i < remoteX.add.Count; i++)
                        if (remoteX.add.At(i).name.Value == modifynodetext)
                        {
                            connStringConfig.addType remote = remoteX.add.At(i);
                            remote.name.Value = "new Name1";
                            remote.connectionString.Value = richTextBox1.Text;
                        }
                    break;
                case "InsertDatabaseConn":
                    for (int i = 0; i < insertX.add.Count; i++)
                        if (insertX.add.At(i).name.Value == modifynodetext)
                        {
                            connStringConfig.addType insert = insertX.add.At(i);
                            insert.name.Value = "new Name1";
                            insert.connectionString.Value = richTextBox1.Text;
                        }
                    break;
                case "DatabaseConnPool":
                    for (int i = 0; i < poolX.add.Count; i++)
                        if (poolX.add.At(i).name.Value == modifynodetext)
                        {
                            connStringConfig.addType pool = poolX.add.At(i);
                            pool.name.Value = "new Name1";
                            pool.connectionString.Value = richTextBox1.Text;
                        }
                    break;
                default:
                    break;
            }
            doc.SaveToFile(streamType.configXmlPath, true);
            SaveTreeViewConn();
        }

        TreeNode selectNode;
        private void treeViewConn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0) return;
            selectNode = e.Node;

            string selectnodetext = selectNode.Text;
            string selectnodeparenttext = selectNode.Parent.Text;
            string conn = null;

            connStringConfig.connStringConfig2 doc = connStringConfig.connStringConfig2.LoadFromFile(streamType.configXmlPath);
            connStringConfig.configurationType level1 = doc.configuration.First;
            connStringConfig.LocalDatabaseConnType localX = level1.LocalDatabaseConn.First;
            connStringConfig.RemoteDatabaseConnType remoteX = level1.RemoteDatabaseConn.First;
            connStringConfig.InsertDatabaseConnType insertX = level1.InsertDatabaseConn.First;
            connStringConfig.DatabaseConnPoolType poolX = level1.DatabaseConnPool.First;

            switch (selectnodeparenttext)
            {
                case "LocalDatabaseConn":
                    for (int i = 0; i < localX.add.Count; i++)
                        if (localX.add.At(i).name.Value == selectnodetext)
                            conn = localX.add.At(i).connectionString.Value;
                    break;
                case "RemoteDatabaseConn":
                    for (int i = 0; i < remoteX.add.Count; i++)
                        if (remoteX.add.At(i).name.Value == selectnodetext)
                            conn = remoteX.add.At(i).connectionString.Value;
                    break;
                case "InsertDatabaseConn":
                    for (int i = 0; i < insertX.add.Count; i++)
                        if (insertX.add.At(i).name.Value == selectnodetext)
                            conn = insertX.add.At(i).connectionString.Value;
                    break;
                case "DatabaseConnPool":
                    for (int i = 0; i < poolX.add.Count; i++)
                        if (poolX.add.At(i).name.Value == selectnodetext)
                            conn = poolX.add.At(i).connectionString.Value;
                    break;
                default:
                    break;
            }

            richTextBox1.Text = conn;
        }

        private void refreshTreeViewConn()
        {
            treeViewConn.Nodes.Clear();
            connStringConfig.connStringConfig2 doc = connStringConfig.connStringConfig2.LoadFromFile(streamType.configXmlPath);
            connStringConfig.configurationType level1 = doc.configuration.First;
            connStringConfig.LocalDatabaseConnType localX = level1.LocalDatabaseConn.First;
            connStringConfig.RemoteDatabaseConnType remoteX = level1.RemoteDatabaseConn.First;
            connStringConfig.InsertDatabaseConnType insertX = level1.InsertDatabaseConn.First;
            connStringConfig.DatabaseConnPoolType poolX = level1.DatabaseConnPool.First;

            TreeNode local = new TreeNode("LocalDatabaseConn");
            for (int i = 0; i < localX.add.Count; i++)
                local.Nodes.Add(localX.add.At(i).name.Value);
            treeViewConn.Nodes.Add(local);

            TreeNode remote = new TreeNode("RemoteDatabaseConn");
            for (int i = 0; i < remoteX.add.Count; i++)
                remote.Nodes.Add(remoteX.add.At(i).name.Value);
            treeViewConn.Nodes.Add(remote);

            TreeNode insert = new TreeNode("InsertDatabaseConn");
            for (int i = 0; i < insertX.add.Count; i++)
                insert.Nodes.Add(insertX.add.At(i).name.Value);
            treeViewConn.Nodes.Add(insert);

            TreeNode pool = new TreeNode("DatabaseConnPool");
            for (int i = 0; i < poolX.add.Count; i++)
                pool.Nodes.Add(poolX.add.At(i).name.Value);
            treeViewConn.Nodes.Add(pool);

            treeViewConn.ExpandAll();

            streamType.LocalConnString = localX.add.At(0).connectionString.Value;
            streamType.RemoteConnString = remoteX.add.At(0).connectionString.Value;
            streamType.RemoteConnString = insertX.add.At(0).connectionString.Value;
        }

        private void SaveTreeViewConn()
        {
            treeViewConn.Nodes.Clear();
            //checkedListBox1.Items.Clear();
            // this.checkedListBox1.Items.AddRange(new object[] { "sqlexpress", "localhost", "192.168.1.12", "......Config" });
            // XElement dataConfig = XElement.Load(streamType.configXmlPath);
            // foreach (var q1 in dataConfig.Elements("connectionStrings"))
            //    checkedListBox1.Items.Add(q1.Element("connectionString").Value);
            connStringConfig.connStringConfig2 doc = connStringConfig.connStringConfig2.LoadFromFile(streamType.configXmlPath);
            connStringConfig.configurationType level1 = doc.configuration.First;
            connStringConfig.LocalDatabaseConnType localX = level1.LocalDatabaseConn.First;
            connStringConfig.RemoteDatabaseConnType remoteX = level1.RemoteDatabaseConn.First;
            connStringConfig.InsertDatabaseConnType insertX = level1.InsertDatabaseConn.First;
            connStringConfig.DatabaseConnPoolType poolX = level1.DatabaseConnPool.First;
            for (int i = 0; i < localX.add.Count; i++)
                localX.add.At(i).name.Value = Conn2Name(localX.add.At(i).connectionString.Value);
            for (int i = 0; i < remoteX.add.Count; i++)
                remoteX.add.At(i).name.Value = Conn2Name(remoteX.add.At(i).connectionString.Value);
            for (int i = 0; i < insertX.add.Count; i++)
                insertX.add.At(i).name.Value = Conn2Name(insertX.add.At(i).connectionString.Value);
            for (int i = 0; i < poolX.add.Count; i++)
                poolX.add.At(i).name.Value = Conn2Name(poolX.add.At(i).connectionString.Value);

            doc.SaveToFile(streamType.configXmlPath, true);
            refreshTreeViewConn();
        }

        private string Conn2Name(string conn)
        {
            string b = conn;
            string[] s = b.Split(new char[] { ';', '=', '"' });
            if (s.Length < 3) return b;
            string name = s[1] + "_" + s[3];
            return name;
        }

        #endregion

        #region  treeView2   treeViewAnalysis 控件 添加、删除、重命名、上移、下移节点
        private void treeViewAnalysis_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                // contextMenu.Show(this, new Point(e.X, e.Y));
                //contextMenuStripConn.Show(this, new Point(e.X, e.Y));
                contextMenuStripAnalysis.Show(this, new Point(e.X, e.Y));
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode nod = new TreeNode("new Name");
            //treeViewConn.SelectedNode.Nodes.Add(nod);
            //treeViewConn.SelectedNode.ExpandAll();
            treeViewAnalysis.SelectedNode.Nodes.Add(nod);
            treeViewAnalysis.SelectedNode.ExpandAll();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断选定的节点是否存在下一级节点 
            if (treeViewAnalysis.SelectedNode.Nodes.Count == 0)
                //删除节点
                treeViewAnalysis.SelectedNode.Remove();
            else
                MessageBox.Show("请先删除此节点中的子节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewAnalysis.LabelEdit = true;
            treeViewAnalysis.SelectedNode.BeginEdit();
        }
        #endregion

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = InputBox("保存成Excel文件?", "请输入Sheet名称", "AAA");
            ExportExcel.ExportForDataGridview(dataGridView1, filename, true);
        }
        private string InputBox(string Caption, string Hint, string Default)
        {
            //by 闫磊 Email:Landgis@126.com,yanleigis@21cn.com 2007.10.10
            Form InputForm = new Form();
            InputForm.MinimizeBox = false;
            InputForm.MaximizeBox = false;
            InputForm.StartPosition = FormStartPosition.CenterScreen;
            InputForm.Width = 220;
            InputForm.Height = 150;
            //InputForm.Font.Name = "宋体";
            //InputForm.Font.Size = 10;

            InputForm.Text = Caption;
            Label lbl = new Label();
            lbl.Text = Hint;
            lbl.Left = 10;
            lbl.Top = 20;
            lbl.Parent = InputForm;
            lbl.AutoSize = true;
            TextBox tb = new TextBox();
            tb.Left = 30;
            tb.Top = 45;
            tb.Width = 160;
            tb.Parent = InputForm;
            tb.Text = Default;
            tb.SelectAll();
            Button btnok = new Button();
            btnok.Left = 30;
            btnok.Top = 80;
            btnok.Parent = InputForm;
            btnok.Text = "确定";
            InputForm.AcceptButton = btnok;//回车响应

            btnok.DialogResult = DialogResult.OK;
            Button btncancal = new Button();
            btncancal.Left = 120;
            btncancal.Top = 80;
            btncancal.Parent = InputForm;
            btncancal.Text = "取消";
            btncancal.DialogResult = DialogResult.Cancel;
            try
            {
                if (InputForm.ShowDialog() == DialogResult.OK)
                {
                    return tb.Text;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                InputForm.Dispose();
            }

        }

    }
}