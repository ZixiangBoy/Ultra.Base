using DevExpress.XtraEditors;
namespace Ultra.User
{
    partial class NewView
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtusr = new DevExpress.XtraEditors.TextEdit();
            this.txtpwd = new DevExpress.XtraEditors.TextEdit();
            this.txtrepwd = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.chk = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrepwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(307, 165);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.labelControl3);
            this.pnlFill.Controls.Add(this.labelControl2);
            this.pnlFill.Controls.Add(this.labelControl1);
            this.pnlFill.Controls.Add(this.chk);
            this.pnlFill.Controls.Add(this.txtusr);
            this.pnlFill.Controls.Add(this.txtpwd);
            this.pnlFill.Controls.Add(this.txtrepwd);
            this.pnlFill.Size = new System.Drawing.Size(307, 119);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Location = new System.Drawing.Point(0, 119);
            this.pnlBottom.Size = new System.Drawing.Size(307, 46);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(220, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(127, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 35);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "确定(&E)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtusr
            // 
            this.txtusr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtusr.Location = new System.Drawing.Point(68, 13);
            this.txtusr.Name = "txtusr";
            this.txtusr.Size = new System.Drawing.Size(227, 20);
            this.txtusr.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "用户名必须填写";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtusr, conditionValidationRule1);
            // 
            // txtpwd
            // 
            this.txtpwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpwd.Location = new System.Drawing.Point(68, 39);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Properties.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(227, 20);
            this.txtpwd.TabIndex = 2;
            // 
            // txtrepwd
            // 
            this.txtrepwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrepwd.Location = new System.Drawing.Point(68, 66);
            this.txtrepwd.Name = "txtrepwd";
            this.txtrepwd.Properties.PasswordChar = '*';
            this.txtrepwd.Size = new System.Drawing.Size(227, 20);
            this.txtrepwd.TabIndex = 27;
            // 
            // chk
            // 
            this.chk.EditValue = true;
            this.chk.Location = new System.Drawing.Point(66, 92);
            this.chk.Name = "chk";
            this.chk.Properties.Caption = "启用";
            this.chk.Size = new System.Drawing.Size(51, 19);
            this.chk.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "用户名";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "密码";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "确认密码";
            // 
            // NewView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(307, 165);
            this.Name = "NewView";
            this.ShowIcon = false;
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.NewView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrepwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextEdit txtrepwd;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private TextEdit txtpwd;
        private TextEdit txtusr;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.CheckEdit chk;
        private LabelControl labelControl3;
        private LabelControl labelControl2;
        private LabelControl labelControl1;
    }
}