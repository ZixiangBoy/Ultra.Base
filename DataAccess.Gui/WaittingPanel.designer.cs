namespace DataAccess.Gui
{
    partial class WaittingPanel
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
            this.lblmsg = new System.Windows.Forms.Label();
            this.MarqueBar = new VistaStyleProgressBar.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblmsg);
            this.panel1.Controls.Add(this.MarqueBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 49);
            this.panel1.TabIndex = 0;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("宋体", 10F);
            this.lblmsg.Location = new System.Drawing.Point(17, 8);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(28, 14);
            this.lblmsg.TabIndex = 1;
            this.lblmsg.Text = "msg";
            // 
            // MarqueBar
            // 
            this.MarqueBar.BackColor = System.Drawing.Color.Transparent;
            this.MarqueBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MarqueBar.Location = new System.Drawing.Point(0, 28);
            this.MarqueBar.Name = "MarqueBar";
            this.MarqueBar.Size = new System.Drawing.Size(271, 21);
            this.MarqueBar.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.MarqueBar.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WaittingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "WaittingPanel";
            this.Size = new System.Drawing.Size(271, 49);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblmsg;
        private VistaStyleProgressBar.ProgressBar MarqueBar;
        private System.Windows.Forms.Timer timer1;
    }
}
