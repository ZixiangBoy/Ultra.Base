namespace Ultra.Login
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtAct = new DevExpress.XtraEditors.TextEdit();
            this.txtpwd = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtAct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(141, 59);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtAct
            // 
            this.txtAct.EditValue = "admin";
            this.txtAct.Location = new System.Drawing.Point(58, 9);
            this.txtAct.Name = "txtAct";
            this.txtAct.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtAct.Properties.Appearance.Options.UseBackColor = true;
            this.txtAct.Size = new System.Drawing.Size(152, 20);
            this.txtAct.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "请输入用户名";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtAct, conditionValidationRule1);
            this.txtAct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpwd_KeyDown);
            // 
            // txtpwd
            // 
            this.txtpwd.EditValue = "";
            this.txtpwd.Location = new System.Drawing.Point(58, 34);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtpwd.Properties.Appearance.Options.UseBackColor = true;
            this.txtpwd.Properties.PasswordChar = '●';
            this.txtpwd.Size = new System.Drawing.Size(152, 20);
            this.txtpwd.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "请输入密码";
            this.dxValidationProvider1.SetValidationRule(this.txtpwd, conditionValidationRule2);
            this.txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpwd_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(58, 59);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "登录(&E)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "用户名:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "密码:";
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 90);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtAct);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit txtAct;
        private DevExpress.XtraEditors.TextEdit txtpwd;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}