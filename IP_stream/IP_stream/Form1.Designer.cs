namespace IP_stream
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ImportCiData");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("InitTable", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("BulkExcute");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("ResultTable", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("OutPutPDCH");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("OutPutTable", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shrinkDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Command = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Analysis = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewAnalysis = new System.Windows.Forms.TreeView();
            this.ConnConfig = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.treeViewConn = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.dualTests1 = new IP_stream.AsynchThread.DualTests();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripConn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addConnectionNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteConnectionNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyConnectionNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripAnalysis = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Command.SuspendLayout();
            this.Analysis.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ConnConfig.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripConn.SuspendLayout();
            this.contextMenuStripAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hiddenToolStripMenuItem,
            this.showToolStripMenuItem,
            this.shrinkDatabaseToolStripMenuItem,
            this.autoUpdateToolStripMenuItem,
            this.exportExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hiddenToolStripMenuItem
            // 
            this.hiddenToolStripMenuItem.Name = "hiddenToolStripMenuItem";
            this.hiddenToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.hiddenToolStripMenuItem.Text = "Hidden";
            this.hiddenToolStripMenuItem.Click += new System.EventHandler(this.hiddenToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exportExcelToolStripMenuItem
            // 
            this.exportExcelToolStripMenuItem.Name = "exportExcelToolStripMenuItem";
            this.exportExcelToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.exportExcelToolStripMenuItem.Text = "ExportExcel";
            this.exportExcelToolStripMenuItem.Click += new System.EventHandler(this.exportExcelToolStripMenuItem_Click);
            // 
            // shrinkDatabaseToolStripMenuItem
            // 
            this.shrinkDatabaseToolStripMenuItem.Name = "shrinkDatabaseToolStripMenuItem";
            this.shrinkDatabaseToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.shrinkDatabaseToolStripMenuItem.Text = "ShrinkDb";
            this.shrinkDatabaseToolStripMenuItem.Click += new System.EventHandler(this.shrinkDatabaseToolStripMenuItem_Click);
            // 
            // autoUpdateToolStripMenuItem
            // 
            this.autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            this.autoUpdateToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.autoUpdateToolStripMenuItem.Text = "AutoUpdate";
            this.autoUpdateToolStripMenuItem.Click += new System.EventHandler(this.autoUpdateToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(185, 17);
            this.toolStripStatusLabel1.Text = "CopyRight by wei.hp.2011.05.30";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel2.Text = "          ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dualTests1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(703, 362);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Command);
            this.tabControl1.Controls.Add(this.Analysis);
            this.tabControl1.Controls.Add(this.ConnConfig);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(237, 362);
            this.tabControl1.TabIndex = 0;
            // 
            // Command
            // 
            this.Command.Controls.Add(this.treeView1);
            this.Command.Location = new System.Drawing.Point(4, 21);
            this.Command.Name = "Command";
            this.Command.Padding = new System.Windows.Forms.Padding(3);
            this.Command.Size = new System.Drawing.Size(229, 337);
            this.Command.TabIndex = 0;
            this.Command.Text = "Command";
            this.Command.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "ImportCiData";
            treeNode1.Text = "ImportCiData";
            treeNode2.Name = "InitTable";
            treeNode2.Text = "InitTable";
            treeNode3.Name = "BulkExcute";
            treeNode3.Text = "BulkExcute";
            treeNode4.Name = "ResultTable";
            treeNode4.Text = "ResultTable";
            treeNode5.Name = "OutPutPDCH";
            treeNode5.Text = "OutPutPDCH";
            treeNode6.Name = "OutPutTable";
            treeNode6.Text = "OutPutTable";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6});
            this.treeView1.PathSeparator = "";
            this.treeView1.Size = new System.Drawing.Size(223, 331);
            this.treeView1.TabIndex = 9;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Analysis
            // 
            this.Analysis.Controls.Add(this.tableLayoutPanel2);
            this.Analysis.Location = new System.Drawing.Point(4, 21);
            this.Analysis.Name = "Analysis";
            this.Analysis.Padding = new System.Windows.Forms.Padding(3);
            this.Analysis.Size = new System.Drawing.Size(229, 337);
            this.Analysis.TabIndex = 1;
            this.Analysis.Text = "Analysis";
            this.Analysis.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.treeViewAnalysis, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(223, 331);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // treeViewAnalysis
            // 
            this.treeViewAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewAnalysis.Location = new System.Drawing.Point(3, 19);
            this.treeViewAnalysis.Name = "treeViewAnalysis";
            this.treeViewAnalysis.Size = new System.Drawing.Size(217, 309);
            this.treeViewAnalysis.TabIndex = 1;
            this.treeViewAnalysis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewAnalysis_MouseDown);
            // 
            // ConnConfig
            // 
            this.ConnConfig.Controls.Add(this.tableLayoutPanel1);
            this.ConnConfig.Location = new System.Drawing.Point(4, 21);
            this.ConnConfig.Name = "ConnConfig";
            this.ConnConfig.Size = new System.Drawing.Size(229, 337);
            this.ConnConfig.TabIndex = 2;
            this.ConnConfig.Text = "ConnConfig";
            this.ConnConfig.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.treeViewConn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Red;
            this.richTextBox1.Location = new System.Drawing.Point(3, 271);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(223, 63);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // treeViewConn
            // 
            this.treeViewConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewConn.Location = new System.Drawing.Point(3, 3);
            this.treeViewConn.Name = "treeViewConn";
            this.treeViewConn.Size = new System.Drawing.Size(223, 229);
            this.treeViewConn.TabIndex = 3;
            this.treeViewConn.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewConn_AfterSelect);
            this.treeViewConn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView3_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "SelectDataBase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dualTests1
            // 
            this.dualTests1.Location = new System.Drawing.Point(27, 84);
            this.dualTests1.Name = "dualTests1";
            this.dualTests1.Size = new System.Drawing.Size(385, 105);
            this.dualTests1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(462, 362);
            this.dataGridView1.TabIndex = 3;
            // 
            // contextMenuStripConn
            // 
            this.contextMenuStripConn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConnectionNodeToolStripMenuItem,
            this.deleteConnectionNodeToolStripMenuItem,
            this.modifyConnectionNodeToolStripMenuItem});
            this.contextMenuStripConn.Name = "contextMenuStrip2";
            this.contextMenuStripConn.Size = new System.Drawing.Size(191, 70);
            // 
            // addConnectionNodeToolStripMenuItem
            // 
            this.addConnectionNodeToolStripMenuItem.Name = "addConnectionNodeToolStripMenuItem";
            this.addConnectionNodeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addConnectionNodeToolStripMenuItem.Text = "AddConnectionNode";
            this.addConnectionNodeToolStripMenuItem.Click += new System.EventHandler(this.addConnectionNodeToolStripMenuItem_Click);
            // 
            // deleteConnectionNodeToolStripMenuItem
            // 
            this.deleteConnectionNodeToolStripMenuItem.Name = "deleteConnectionNodeToolStripMenuItem";
            this.deleteConnectionNodeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteConnectionNodeToolStripMenuItem.Text = "DeleteConnectionNode";
            this.deleteConnectionNodeToolStripMenuItem.Click += new System.EventHandler(this.deleteConnectionNodeToolStripMenuItem_Click);
            // 
            // modifyConnectionNodeToolStripMenuItem
            // 
            this.modifyConnectionNodeToolStripMenuItem.Name = "modifyConnectionNodeToolStripMenuItem";
            this.modifyConnectionNodeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.modifyConnectionNodeToolStripMenuItem.Text = "ModifyConnectionNode";
            this.modifyConnectionNodeToolStripMenuItem.Click += new System.EventHandler(this.modifyConnectionNodeToolStripMenuItem_Click);
            // 
            // contextMenuStripAnalysis
            // 
            this.contextMenuStripAnalysis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.modifyToolStripMenuItem});
            this.contextMenuStripAnalysis.Name = "contextMenuStripAnalysis";
            this.contextMenuStripAnalysis.Size = new System.Drawing.Size(107, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 408);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IP Stream";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Command.ResumeLayout(false);
            this.Analysis.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ConnConfig.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripConn.ResumeLayout(false);
            this.contextMenuStripAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ToolStrip toolStrip1;
        //private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Command;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage Analysis;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage ConnConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TreeView treeViewAnalysis;
        private System.Windows.Forms.ToolStripMenuItem hiddenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripConn;
        private System.Windows.Forms.TreeView treeViewConn;
        private System.Windows.Forms.ToolStripMenuItem addConnectionNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteConnectionNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyConnectionNodeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAnalysis;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportExcelToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shrinkDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private AsynchThread.DualTests dualTests1;
    }
}

