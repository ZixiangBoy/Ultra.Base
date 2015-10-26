namespace DataAccess.Gui
{
    partial class DataBaseConfigWizard
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.waittingPanel1 = new DataAccess.Gui.WaittingPanel();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.cmbValidType = new System.Windows.Forms.ComboBox();
            this.cmbuid = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbsvr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 190);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.waittingPanel1);
            this.groupBox1.Controls.Add(this.cmbDataBase);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtpwd);
            this.groupBox1.Controls.Add(this.cmbValidType);
            this.groupBox1.Controls.Add(this.cmbuid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbsvr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 182);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // waittingPanel1
            // 
            this.waittingPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waittingPanel1.AutoMarquee = false;
            this.waittingPanel1.Location = new System.Drawing.Point(74, 23);
            this.waittingPanel1.Message = "msg";
            this.waittingPanel1.Name = "waittingPanel1";
            this.waittingPanel1.Size = new System.Drawing.Size(271, 52);
            this.waittingPanel1.TabIndex = 7;
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(100, 151);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(281, 20);
            this.cmbDataBase.TabIndex = 4;
            this.cmbDataBase.DropDown += new System.EventHandler(this.cmbDataBase_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据库:";
            // 
            // txtpwd
            // 
            this.txtpwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpwd.Location = new System.Drawing.Point(100, 119);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(281, 21);
            this.txtpwd.TabIndex = 3;
            // 
            // cmbValidType
            // 
            this.cmbValidType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValidType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValidType.FormattingEnabled = true;
            this.cmbValidType.Items.AddRange(new object[] {
            "SQL Server 身份验证",
            "Windows 身份验证"});
            this.cmbValidType.Location = new System.Drawing.Point(100, 52);
            this.cmbValidType.Name = "cmbValidType";
            this.cmbValidType.Size = new System.Drawing.Size(281, 20);
            this.cmbValidType.TabIndex = 1;
            this.cmbValidType.SelectedIndexChanged += new System.EventHandler(this.cmbValidType_SelectedIndexChanged);
            // 
            // cmbuid
            // 
            this.cmbuid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbuid.FormattingEnabled = true;
            this.cmbuid.Location = new System.Drawing.Point(100, 87);
            this.cmbuid.Name = "cmbuid";
            this.cmbuid.Size = new System.Drawing.Size(281, 20);
            this.cmbuid.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码:";
            // 
            // cmbsvr
            // 
            this.cmbsvr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbsvr.FormattingEnabled = true;
            this.cmbsvr.Location = new System.Drawing.Point(100, 20);
            this.cmbsvr.Name = "cmbsvr";
            this.cmbsvr.Size = new System.Drawing.Size(281, 20);
            this.cmbsvr.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "身份验证:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "服务器名称:";
            // 
            // DataBaseConfigWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DataBaseConfigWizard";
            this.Size = new System.Drawing.Size(413, 190);
            this.Load += new System.EventHandler(this.DataBaseConfigWizard_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private WaittingPanel waittingPanel1;
        public System.Windows.Forms.TextBox txtpwd;
        public System.Windows.Forms.ComboBox cmbValidType;
        public System.Windows.Forms.ComboBox cmbuid;
        public System.Windows.Forms.ComboBox cmbsvr;
        public System.Windows.Forms.ComboBox cmbDataBase;
    }
}
