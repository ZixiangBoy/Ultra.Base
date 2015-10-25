using DevExpress.XtraEditors;
namespace Ultra.Role
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txtname = new DevExpress.XtraEditors.TextEdit();
            this.txtdesc = new DevExpress.XtraEditors.MemoEdit();
            this.chk = new DevExpress.XtraEditors.CheckEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(282, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(197, 6);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.labelControl2);
            this.pnlFill.Controls.Add(this.labelControl1);
            this.pnlFill.Controls.Add(this.chk);
            this.pnlFill.Controls.Add(this.txtdesc);
            this.pnlFill.Controls.Add(this.txtname);
            // 
            // txtname
            // 
            this.txtname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtname.Location = new System.Drawing.Point(53, 12);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(314, 20);
            this.txtname.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "名称必须填写";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtname, conditionValidationRule1);
            // 
            // txtdesc
            // 
            this.txtdesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdesc.Location = new System.Drawing.Point(53, 39);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(314, 96);
            this.txtdesc.TabIndex = 2;
            // 
            // chk
            // 
            this.chk.EditValue = true;
            this.chk.Location = new System.Drawing.Point(10, 150);
            this.chk.Name = "chk";
            this.chk.Properties.Caption = "启用";
            this.chk.Size = new System.Drawing.Size(75, 19);
            this.chk.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "描述";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "名称";
            // 
            // NewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 235);
            this.Name = "NewView";
            this.Text = "编辑角色信息";
            this.Load += new System.EventHandler(this.NewView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chk;
        private DevExpress.XtraEditors.MemoEdit txtdesc;
        private TextEdit txtname;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private LabelControl labelControl2;
        private LabelControl labelControl1;
    }
}