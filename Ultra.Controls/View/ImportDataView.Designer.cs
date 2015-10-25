namespace Ultra.Controls.View {
    partial class ImportDataView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fileBrowser1 = new Ultra.Controls.FileBrowser();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barBtnDelFocus = new DevExpress.XtraBars.BarButtonItem();
            this.btnCtl1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnChk = new DevExpress.XtraEditors.SimpleButton();
            this.btnExp = new DevExpress.XtraEditors.SimpleButton();
            this.btnImp = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(4002, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3917, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(844, 423);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.panelControl1);
            this.pnlFill.Size = new System.Drawing.Size(844, 377);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 377);
            this.pnlBottom.Size = new System.Drawing.Size(844, 46);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.fileBrowser1);
            this.panelControl1.Controls.Add(this.btnCtl1);
            this.panelControl1.Controls.Add(this.btnChk);
            this.panelControl1.Controls.Add(this.btnExp);
            this.panelControl1.Controls.Add(this.btnImp);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(840, 39);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "文件";
            // 
            // fileBrowser1
            // 
            this.fileBrowser1.AllowDrop = true;
            this.fileBrowser1.Location = new System.Drawing.Point(41, 10);
            this.fileBrowser1.MenuManager = this.barManager1;
            this.fileBrowser1.Name = "fileBrowser1";
            this.fileBrowser1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "浏览...", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.fileBrowser1.Properties.ReadOnly = true;
            this.fileBrowser1.Size = new System.Drawing.Size(351, 21);
            this.fileBrowser1.TabIndex = 5;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnDelFocus});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(844, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 423);
            this.barDockControlBottom.Size = new System.Drawing.Size(844, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 423);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(844, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 423);
            // 
            // barBtnDelFocus
            // 
            this.barBtnDelFocus.Caption = "排除所选行";
            this.barBtnDelFocus.Id = 0;
            this.barBtnDelFocus.Name = "barBtnDelFocus";
            this.barBtnDelFocus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDelFocus_ItemClick);
            // 
            // btnCtl1
            // 
            this.btnCtl1.Location = new System.Drawing.Point(665, 9);
            this.btnCtl1.Name = "btnCtl1";
            this.btnCtl1.Size = new System.Drawing.Size(110, 23);
            this.btnCtl1.TabIndex = 4;
            this.btnCtl1.Text = "生成模板文件";
            this.btnCtl1.Click += new System.EventHandler(this.btnCtl1_Click);
            // 
            // btnChk
            // 
            this.btnChk.Location = new System.Drawing.Point(404, 9);
            this.btnChk.Name = "btnChk";
            this.btnChk.Size = new System.Drawing.Size(75, 23);
            this.btnChk.TabIndex = 3;
            this.btnChk.Text = "验证数据";
            this.btnChk.Click += new System.EventHandler(this.btnChk_Click);
            // 
            // btnExp
            // 
            this.btnExp.Location = new System.Drawing.Point(485, 9);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(93, 23);
            this.btnExp.TabIndex = 2;
            this.btnExp.Text = "导出当前数据";
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnImp
            // 
            this.btnImp.Enabled = false;
            this.btnImp.Location = new System.Drawing.Point(584, 9);
            this.btnImp.Name = "btnImp";
            this.btnImp.Size = new System.Drawing.Size(75, 23);
            this.btnImp.TabIndex = 1;
            this.btnImp.Text = "导入";
            this.btnImp.Click += new System.EventHandler(this.btnImp_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDelFocus)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // ImportDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 423);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ImportDataView";
            this.Text = "数据导入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileBrowser1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnCtl1;
        public DevExpress.XtraEditors.SimpleButton btnChk;
        public DevExpress.XtraEditors.SimpleButton btnExp;
        public DevExpress.XtraEditors.SimpleButton btnImp;
        public DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarButtonItem barBtnDelFocus;
        public DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public FileBrowser fileBrowser1;
    }
}