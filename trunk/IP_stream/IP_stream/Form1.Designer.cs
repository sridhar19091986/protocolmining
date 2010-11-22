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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("AlterPrimaryKey");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("InitImeiCiTypeTable");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("InitMlocationTable");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("InitTable", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("InsertCiType");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("InsertImeiType");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("UpdateImeiType");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("InsertResultTable");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("ResultTable", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Command = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Analysis = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.ConnConfig = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifyConnStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addConnStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteConnStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.updateConfig = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Command.SuspendLayout();
            this.Analysis.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ConnConfig.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hiddenToolStripMenuItem,
            this.showToolStripMenuItem});
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel1.Text = "==";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel2.Text = "==";
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
            treeNode1.Name = "AlterPrimaryKey";
            treeNode1.Text = "AlterPrimaryKey";
            treeNode2.Name = "InitImeiCiTypeTable";
            treeNode2.Text = "InitImeiCiTypeTable";
            treeNode3.Name = "InitMlocationTable";
            treeNode3.Text = "InitMlocationTable";
            treeNode4.Name = "InitTable";
            treeNode4.Text = "InitTable";
            treeNode5.Name = "InsertCiType";
            treeNode5.Text = "InsertCiType";
            treeNode6.Name = "InsertImeiType";
            treeNode6.Text = "InsertImeiType";
            treeNode7.Name = "UpdateImeiType";
            treeNode7.Text = "UpdateImeiType";
            treeNode8.Name = "InsertResultTable";
            treeNode8.Text = "InsertResultTable";
            treeNode9.Name = "ResultTable";
            treeNode9.Text = "ResultTable";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode9});
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
            this.tableLayoutPanel2.Controls.Add(this.treeView2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(223, 331);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Location = new System.Drawing.Point(3, 19);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(217, 309);
            this.treeView2.TabIndex = 1;
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
            this.tableLayoutPanel1.Controls.Add(this.checkedListBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.updateConfig, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "sqlexpress",
            "localhost",
            "192.168.1.12",
            "......Config"});
            this.checkedListBox1.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(223, 137);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyConnStringToolStripMenuItem,
            this.addConnStringToolStripMenuItem,
            this.deleteConnStringToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 70);
            // 
            // modifyConnStringToolStripMenuItem
            // 
            this.modifyConnStringToolStripMenuItem.Name = "modifyConnStringToolStripMenuItem";
            this.modifyConnStringToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.modifyConnStringToolStripMenuItem.Text = "Modify ConnString";
            this.modifyConnStringToolStripMenuItem.Click += new System.EventHandler(this.modifyConnStringToolStripMenuItem_Click);
            // 
            // addConnStringToolStripMenuItem
            // 
            this.addConnStringToolStripMenuItem.Name = "addConnStringToolStripMenuItem";
            this.addConnStringToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addConnStringToolStripMenuItem.Text = "Add ConnString";
            this.addConnStringToolStripMenuItem.Click += new System.EventHandler(this.addConnStringToolStripMenuItem_Click);
            // 
            // deleteConnStringToolStripMenuItem
            // 
            this.deleteConnStringToolStripMenuItem.Name = "deleteConnStringToolStripMenuItem";
            this.deleteConnStringToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.deleteConnStringToolStripMenuItem.Text = "Delete ConnString";
            this.deleteConnStringToolStripMenuItem.Click += new System.EventHandler(this.deleteConnStringToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 196);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(223, 138);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // updateConfig
            // 
            this.updateConfig.Location = new System.Drawing.Point(3, 146);
            this.updateConfig.Name = "updateConfig";
            this.updateConfig.Size = new System.Drawing.Size(75, 23);
            this.updateConfig.TabIndex = 2;
            this.updateConfig.Text = "updateConfig";
            this.updateConfig.UseVisualStyleBackColor = true;
            this.updateConfig.Click += new System.EventHandler(this.button_updateConfig_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 408);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IP Stream";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Command.ResumeLayout(false);
            this.Analysis.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ConnConfig.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button updateConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ToolStripMenuItem hiddenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modifyConnStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addConnStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteConnStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
    }
}

