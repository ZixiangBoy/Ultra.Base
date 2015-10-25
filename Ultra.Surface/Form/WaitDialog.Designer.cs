namespace Ultra.Surface.Form
{
    partial class WaitDialog
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
            this.bgkwkr = new System.ComponentModel.BackgroundWorker();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.pgb = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgb.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bgkwkr
            // 
            this.bgkwkr.WorkerSupportsCancellation = true;
            this.bgkwkr.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgkwkr_DoWork);
            this.bgkwkr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgkwkr_RunWorkerCompleted);
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(12, 26);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(212, 21);
            this.marqueeProgressBarControl1.TabIndex = 0;
            // 
            // pgb
            // 
            this.pgb.Location = new System.Drawing.Point(69, -4);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(97, 10);
            this.pgb.TabIndex = 1;
            this.pgb.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.Location = new System.Drawing.Point(16, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(47, 14);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "msghere";
            // 
            // WaitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 59);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提示";
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgb.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.ProgressBarControl pgb;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private System.ComponentModel.BackgroundWorker bgkwkr;
    }
}