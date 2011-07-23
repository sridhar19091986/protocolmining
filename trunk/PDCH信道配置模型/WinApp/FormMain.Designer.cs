namespace WinApp
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtPath1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPath2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPath3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnOption1 = new DevComponents.DotNetBar.ButtonX();
            this.btnOption2 = new DevComponents.DotNetBar.ButtonX();
            this.btnOption3 = new DevComponents.DotNetBar.ButtonX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(19, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(105, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "输入小区流量占比";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(19, 68);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(118, 18);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "输入小区PS寻呼时延";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.Location = new System.Drawing.Point(19, 119);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(130, 18);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "输入小区PDCH占用统计";
            // 
            // txtPath1
            // 
            // 
            // 
            // 
            this.txtPath1.Border.Class = "TextBoxBorder";
            this.txtPath1.Location = new System.Drawing.Point(19, 36);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.Size = new System.Drawing.Size(200, 21);
            this.txtPath1.TabIndex = 3;
            // 
            // txtPath2
            // 
            // 
            // 
            // 
            this.txtPath2.Border.Class = "TextBoxBorder";
            this.txtPath2.Location = new System.Drawing.Point(19, 86);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.Size = new System.Drawing.Size(200, 21);
            this.txtPath2.TabIndex = 4;
            // 
            // txtPath3
            // 
            // 
            // 
            // 
            this.txtPath3.Border.Class = "TextBoxBorder";
            this.txtPath3.Location = new System.Drawing.Point(19, 137);
            this.txtPath3.Name = "txtPath3";
            this.txtPath3.Size = new System.Drawing.Size(200, 21);
            this.txtPath3.TabIndex = 5;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.Location = new System.Drawing.Point(323, 18);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 18);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "选择用户感知";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(323, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存结果";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(417, 135);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOption1
            // 
            this.btnOption1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOption1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOption1.Location = new System.Drawing.Point(224, 35);
            this.btnOption1.Name = "btnOption1";
            this.btnOption1.Size = new System.Drawing.Size(43, 23);
            this.btnOption1.TabIndex = 10;
            this.btnOption1.Text = "选择";
            this.btnOption1.Click += new System.EventHandler(this.btnOption1_Click);
            // 
            // btnOption2
            // 
            this.btnOption2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOption2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOption2.Location = new System.Drawing.Point(224, 85);
            this.btnOption2.Name = "btnOption2";
            this.btnOption2.Size = new System.Drawing.Size(43, 23);
            this.btnOption2.TabIndex = 11;
            this.btnOption2.Text = "选择";
            this.btnOption2.Click += new System.EventHandler(this.btnOption2_Click);
            // 
            // btnOption3
            // 
            this.btnOption3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOption3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOption3.Location = new System.Drawing.Point(224, 136);
            this.btnOption3.Name = "btnOption3";
            this.btnOption3.Size = new System.Drawing.Size(43, 23);
            this.btnOption3.TabIndex = 12;
            this.btnOption3.Text = "选择";
            this.btnOption3.Click += new System.EventHandler(this.btnOption3_Click);
            // 
            // progressBarX1
            // 
            this.progressBarX1.Location = new System.Drawing.Point(19, 193);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(473, 17);
            this.progressBarX1.TabIndex = 13;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.Location = new System.Drawing.Point(19, 170);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 18);
            this.labelX5.TabIndex = 14;
            this.labelX5.Text = "处理进度";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "一般",
            "较好",
            "良好"});
            this.comboBox1.Location = new System.Drawing.Point(322, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 20);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 216);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.btnOption3);
            this.Controls.Add(this.btnOption2);
            this.Controls.Add(this.btnOption1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtPath3);
            this.Controls.Add(this.txtPath2);
            this.Controls.Add(this.txtPath1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(520, 250);
            this.MinimumSize = new System.Drawing.Size(520, 250);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDCH信道配置模型";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPath1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPath2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPath3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnOption1;
        private DevComponents.DotNetBar.ButtonX btnOption2;
        private DevComponents.DotNetBar.ButtonX btnOption3;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.ComboBox comboBox1;





    }
}

