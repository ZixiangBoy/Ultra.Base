namespace Ultra.LoginBind
{
    partial class EditView
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.memedt = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memedt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(321, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(228, 6);
            this.btnOK.Text = "保存(&S)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(408, 352);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.groupControl1);
            this.pnlFill.Size = new System.Drawing.Size(408, 306);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 306);
            this.pnlBottom.Size = new System.Drawing.Size(408, 46);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.memedt);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(404, 302);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "已备案的MAC列表";
            // 
            // memedt
            // 
            this.memedt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memedt.Location = new System.Drawing.Point(2, 22);
            this.memedt.Name = "memedt";
            this.memedt.Size = new System.Drawing.Size(400, 278);
            this.memedt.TabIndex = 0;
            // 
            // EditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 352);
            this.Name = "EditView";
            this.Text = "MAC列表";
            this.Load += new System.EventHandler(this.EditView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memedt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit memedt;
    }
}