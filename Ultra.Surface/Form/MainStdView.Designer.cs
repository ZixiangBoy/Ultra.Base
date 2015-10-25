namespace Ultra.Surface.Form
{
    partial class MainStdView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainStdView));
            this.baseDockMgr = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpQuery = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.baseDockMgr)).BeginInit();
            this.dpQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseDockMgr
            // 
            this.baseDockMgr.Form = this;
            this.baseDockMgr.MenuManager = this.baseBarMgr;
            this.baseDockMgr.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpQuery});
            this.baseDockMgr.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpQuery
            // 
            this.dpQuery.Controls.Add(this.dockPanel1_Container);
            this.dpQuery.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dpQuery.ID = new System.Guid("38d81ccf-b4d3-457e-b2ce-3944a73cb70d");
            this.dpQuery.Location = new System.Drawing.Point(0, 31);
            this.dpQuery.Name = "dpQuery";
            this.dpQuery.OriginalSize = new System.Drawing.Size(200, 116);
            this.dpQuery.Size = new System.Drawing.Size(808, 116);
            this.dpQuery.Text = "查询条件";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(800, 89);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // MainStdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 485);
            this.Controls.Add(this.dpQuery);
            this.Name = "MainStdView";
            this.Text = "MainStdView";
            this.Controls.SetChildIndex(this.dpQuery, 0);
            ((System.ComponentModel.ISupportInitialize)(this.baseDockMgr)).EndInit();
            this.dpQuery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraBars.Docking.DockManager baseDockMgr;
        public DevExpress.XtraBars.Docking.DockPanel dpQuery;
        public DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;

    }
}