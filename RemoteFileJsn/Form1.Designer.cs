namespace RemoteFileJsn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSvrDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnBrowers = new System.Windows.Forms.Button();
            this.btnGenUpdateConfig = new System.Windows.Forms.Button();
            this.txtFileDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstFile = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.fdlg = new System.Windows.Forms.FolderBrowserDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSvrDir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnBrowers);
            this.panel1.Controls.Add(this.btnGenUpdateConfig);
            this.panel1.Controls.Add(this.txtFileDir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 82);
            this.panel1.TabIndex = 0;
            // 
            // txtSvrDir
            // 
            this.txtSvrDir.Location = new System.Drawing.Point(85, 40);
            this.txtSvrDir.Name = "txtSvrDir";
            this.txtSvrDir.Size = new System.Drawing.Size(111, 21);
            this.txtSvrDir.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "客户DB名称";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(512, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(123, 32);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "上传文件至服务器";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(427, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "自动过滤";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnBrowers
            // 
            this.btnBrowers.Location = new System.Drawing.Point(374, 10);
            this.btnBrowers.Name = "btnBrowers";
            this.btnBrowers.Size = new System.Drawing.Size(46, 23);
            this.btnBrowers.TabIndex = 2;
            this.btnBrowers.Text = "……";
            this.btnBrowers.UseVisualStyleBackColor = true;
            this.btnBrowers.Click += new System.EventHandler(this.btnBrowers_Click);
            // 
            // btnGenUpdateConfig
            // 
            this.btnGenUpdateConfig.Location = new System.Drawing.Point(216, 37);
            this.btnGenUpdateConfig.Name = "btnGenUpdateConfig";
            this.btnGenUpdateConfig.Size = new System.Drawing.Size(106, 33);
            this.btnGenUpdateConfig.TabIndex = 0;
            this.btnGenUpdateConfig.Text = "生成Main.txt 并发布至服务器";
            this.btnGenUpdateConfig.UseVisualStyleBackColor = true;
            this.btnGenUpdateConfig.Click += new System.EventHandler(this.btnGenUpdateConfig_Click);
            // 
            // txtFileDir
            // 
            this.txtFileDir.Location = new System.Drawing.Point(84, 10);
            this.txtFileDir.Name = "txtFileDir";
            this.txtFileDir.Size = new System.Drawing.Size(284, 21);
            this.txtFileDir.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目录选择";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(813, 361);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(813, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(805, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstFile
            // 
            this.lstFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFile.FullRowSelect = true;
            this.lstFile.Location = new System.Drawing.Point(3, 3);
            this.lstFile.Name = "lstFile";
            this.lstFile.Size = new System.Drawing.Size(799, 329);
            this.lstFile.TabIndex = 0;
            this.lstFile.UseCompatibleStateImageBehavior = false;
            this.lstFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件";
            this.columnHeader1.Width = 245;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MD5";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "进度";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(805, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Jsn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(799, 329);
            this.panel4.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(799, 329);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // sfd
            // 
            this.sfd.FileName = "MainJsn.txt";
            this.sfd.Filter = "*.txt|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 443);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动升级包制作";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrowers;
        private System.Windows.Forms.TextBox txtFileDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FolderBrowserDialog fdlg;
        private System.Windows.Forms.ListView lstFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenUpdateConfig;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtSvrDir;
    }
}

