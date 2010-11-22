using System;
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
            handleTable h = new handleTable();
            switch (e.Node.Name)
            {
                case "AlterPrimaryKey":
                    toolStripStatusLabel1.Text = h.AlterPrimaryKey();
                    break;
                case "InitImeiCiTypeTable":
                    toolStripStatusLabel1.Text = h.InitImeiCiTypeTable();
                    break;
                case "InitMlocationTable":
                    toolStripStatusLabel1.Text = h.InitMlocationTable();
                    break;

                case "InsertImeiType":
                    imeiTypeClass _imeiTypeClass = new imeiTypeClass(true);
                    //Parallel.For(0, 2, i => { MessageBox.Show(i.ToString()); });
                    Parallel.For(0, 2, i => { _imeiTypeClass.InsertImeiType(_imeiTypeClass, i); });
                    Thread.Sleep(1); GC.Collect(); Application.DoEvents();
                    Parallel.For(2, 4, i => { _imeiTypeClass.InsertImeiType(_imeiTypeClass, i); });
                    break;
                case "InsertCiType":
                    ciType _ciType = new ciType(true);
                    Task t1 = new Task(() => { _ciType.InsertCiType(_ciType, 0); }); t1.Start();
                    break;
                case "UpdateImeiType":
                    imeiTypeClass _imeiTypeClass_false = new imeiTypeClass(false);
                    Task t2 = new Task(() => { _imeiTypeClass_false.UpdateImeiType(); }); t2.Start();
                    break;
                case "InsertResultTable":
                    mLocatingConvert ml = new mLocatingConvert();
                    Parallel.For(0, 2, i => { ml.SendOrders(ml, i); });
                    Thread.Sleep(1); GC.Collect(); Application.DoEvents();
                    Parallel.For(0, 4, i => { ml.SendOrders(ml, i); });
                    break;

                default:
                    QueryTable(e.Node.Text);
                    break;
            }
        }

        private void QueryTable(string tbName)
        {
            //只有IP_stream不在本地
            if (tbName == "ciCoverType" || tbName == "imeiType")
                using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
                {
                    dataGridView1.DataSource = mess.GetTableByName(tbName);
                    toolStripStatusLabel1.Text = mess.Connection.ConnectionString;
                }
            else
                using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.RemoteConnString))
                {
                    dataGridView1.DataSource = mess.GetTableByName(tbName);
                    toolStripStatusLabel1.Text = mess.Connection.ConnectionString;
                }
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs c)
        {
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            string a = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
            string b = null;
            foreach (var q1 in dataConfig.Elements("connectionStrings"))
                if (q1.Element("connectionString").Value == a)
                    b = a;
            if (b == null)
                b = appConfig.GetConnectionStringsConfig("IP_stream.Properties.Settings.IP_StreamConnectionString");
            richTextBox1.Text = b;
        }

        private void button_updateConfig_Click(object sender, EventArgs e)
        {
            #region   修改远程数据库
            streamType.RemoteConnString = richTextBox1.Text;
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            XElement mod = dataConfig.Elements("connectionStrings").ElementAt(0);
            mod.Element("connectionString").Value = streamType.RemoteConnString;
            mod.Element("DateTime").Value = DateTime.Now.ToString();
            dataConfig.Save(streamType.configXmlPath);
            refreshCheckListBox();
            toolStripStatusLabel2.Text = streamType.RemoteConnString;
            #endregion

            streamType.InsertConnString = streamType.RemoteConnString;
            MessageBox.Show("OK");
        }

        private void refreshCheckListBox()
        {
            checkedListBox1.Items.Clear();
            this.checkedListBox1.Items.AddRange(new object[] { "sqlexpress", "localhost", "192.168.1.12", "......Config" });
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            foreach (var q1 in dataConfig.Elements("connectionStrings"))
                checkedListBox1.Items.Add(q1.Element("connectionString").Value);
        }
        private void refreshTreeView1()
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
        private void refreshTreeView2()
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
                treeView2.Nodes.Add(tn0);
            }
            treeView2.ExpandAll();
        }
        private void Form1_Load(object sender, EventArgs c)
        {

            #region   远程数据库，取xml文件中第一个连接
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            XElement mod = dataConfig.Elements("connectionStrings").ElementAt(0);
            streamType.RemoteConnString = mod.Element("connectionString").Value;
            toolStripStatusLabel2.Text = streamType.RemoteConnString;
            #endregion

            refreshCheckListBox();
            refreshTreeView1();
            refreshTreeView2();

            streamType.InsertConnString = streamType.RemoteConnString;
        }

        private void hiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
        }

        private void modifyConnStringToolStripMenuItem_Click(object sender, EventArgs args)
        {
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            string rem = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
            XElement mod = dataConfig.Elements("connectionStrings").Where(e => e.Element("connectionString").Value == rem).First();
            mod.Element("connectionString").Value = richTextBox1.Text;
            mod.Element("DateTime").Value = DateTime.Now.ToString();
            dataConfig.Save(streamType.configXmlPath);
            refreshCheckListBox();
        }

        private void addConnStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            XElement addx = new XElement("connectionStrings",
            new XElement("connectionString", richTextBox1.Text),
            new XElement("DateTime", DateTime.Now));
            dataConfig.Add(addx);
            dataConfig.Save(streamType.configXmlPath);
            refreshCheckListBox();
        }

        private void deleteConnStringToolStripMenuItem_Click(object sender, EventArgs args)
        {
            XElement dataConfig = XElement.Load(streamType.configXmlPath);
            string rem = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
            dataConfig.Elements("connectionStrings").Where(e => e.Element("connectionString").Value == rem).First().Remove();
            dataConfig.Save(streamType.configXmlPath);
            refreshCheckListBox();
        }

    }
}
