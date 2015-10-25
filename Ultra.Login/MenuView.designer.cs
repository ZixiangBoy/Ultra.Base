using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
namespace Ultra.Login
{
    partial class MenuView
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
            this.sptPanel1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeCtl1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupPanel1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSaveToSvr = new DevExpress.XtraEditors.SimpleButton();
            this.groupPanel3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveMnuItem = new DevExpress.XtraEditors.SimpleButton();
            this.chkUsing = new DevExpress.XtraEditors.CheckEdit();
            this.txtmnuAsmName = new DevExpress.XtraEditors.TextEdit();
            this.txtmnuClassName = new DevExpress.XtraEditors.TextEdit();
            this.txtmnuName = new DevExpress.XtraEditors.TextEdit();
            this.groupPanel2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveMnuGrp = new DevExpress.XtraEditors.SimpleButton();
            this.txtmnuGrp = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barBtnLogoff = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barLabel = new DevExpress.XtraBars.BarStaticItem();
            this.barSubOpt = new DevExpress.XtraBars.BarSubItem();
            this.barSkin = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barChkSys = new DevExpress.XtraBars.BarCheckItem();
            this.barChkTaobao = new DevExpress.XtraBars.BarCheckItem();
            this.barBtnSysMnu = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barBtnSysInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barMnuTaobao = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barbtnMnuGrp = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnMnuItem = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.popMenuCtl1 = new DevExpress.XtraBars.PopupMenu();
            this.fdlg = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sptPanel1)).BeginInit();
            this.sptPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel3)).BeginInit();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuAsmName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel2)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuGrp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenuCtl1)).BeginInit();
            this.SuspendLayout();
            // 
            // sptPanel1
            // 
            this.sptPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptPanel1.Location = new System.Drawing.Point(0, 0);
            this.sptPanel1.Name = "sptPanel1";
            this.sptPanel1.Panel1.Controls.Add(this.treeCtl1);
            this.sptPanel1.Panel1.Text = "Panel1";
            this.sptPanel1.Panel2.Controls.Add(this.groupPanel1);
            this.sptPanel1.Panel2.Text = "Panel2";
            this.sptPanel1.Size = new System.Drawing.Size(732, 448);
            this.sptPanel1.SplitterPosition = 214;
            this.sptPanel1.TabIndex = 0;
            this.sptPanel1.Text = "sptPanel1";
            // 
            // treeCtl1
            // 
            this.treeCtl1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCtl1.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always;
            this.treeCtl1.Location = new System.Drawing.Point(0, 0);
            this.treeCtl1.Name = "treeCtl1";
            this.treeCtl1.BeginUnboundLoad();
            this.treeCtl1.AppendNode(new object[] {
            "1"}, -1);
            this.treeCtl1.AppendNode(new object[] {
            "11"}, 0);
            this.treeCtl1.AppendNode(new object[] {
            "2"}, -1);
            this.treeCtl1.AppendNode(new object[] {
            "22"}, 2);
            this.treeCtl1.AppendNode(new object[] {
            "222"}, 3);
            this.treeCtl1.AppendNode(new object[] {
            "3"}, -1);
            this.treeCtl1.EndUnboundLoad();
            this.treeCtl1.OptionsBehavior.DragNodes = true;
            this.treeCtl1.OptionsBehavior.Editable = false;
            this.treeCtl1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeCtl1.OptionsSelection.InvertSelection = true;
            this.treeCtl1.OptionsView.ShowColumns = false;
            this.treeCtl1.OptionsView.ShowFocusedFrame = false;
            this.treeCtl1.OptionsView.ShowHorzLines = false;
            this.treeCtl1.OptionsView.ShowIndicator = false;
            this.treeCtl1.OptionsView.ShowVertLines = false;
            this.treeCtl1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeCtl1.Size = new System.Drawing.Size(214, 448);
            this.treeCtl1.TabIndex = 0;
            this.treeCtl1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.treeCtl1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeCtl1_FocusedNodeChanged);
            this.treeCtl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeCtl1_MouseUp);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 86;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 91;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Controls.Add(this.btnSaveToSvr);
            this.groupPanel1.Controls.Add(this.groupPanel3);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(513, 448);
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "菜单编辑";
            // 
            // btnSaveToSvr
            // 
            this.btnSaveToSvr.Location = new System.Drawing.Point(14, 377);
            this.btnSaveToSvr.Name = "btnSaveToSvr";
            this.btnSaveToSvr.Size = new System.Drawing.Size(130, 23);
            this.btnSaveToSvr.TabIndex = 1;
            this.btnSaveToSvr.Text = "保存菜单至服务器";
            this.btnSaveToSvr.Click += new System.EventHandler(this.btnSaveToSvr_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel3.Controls.Add(this.labelControl4);
            this.groupPanel3.Controls.Add(this.labelControl3);
            this.groupPanel3.Controls.Add(this.labelControl2);
            this.groupPanel3.Controls.Add(this.btnSaveMnuItem);
            this.groupPanel3.Controls.Add(this.chkUsing);
            this.groupPanel3.Controls.Add(this.txtmnuAsmName);
            this.groupPanel3.Controls.Add(this.txtmnuClassName);
            this.groupPanel3.Controls.Add(this.txtmnuName);
            this.groupPanel3.Location = new System.Drawing.Point(14, 140);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(487, 217);
            this.groupPanel3.TabIndex = 0;
            this.groupPanel3.Text = "菜单项";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "主画面类";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 94);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "程序集名称";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "菜单项名称";
            // 
            // btnSaveMnuItem
            // 
            this.btnSaveMnuItem.Location = new System.Drawing.Point(7, 152);
            this.btnSaveMnuItem.Name = "btnSaveMnuItem";
            this.btnSaveMnuItem.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMnuItem.TabIndex = 1;
            this.btnSaveMnuItem.Text = "保存修改";
            this.btnSaveMnuItem.Click += new System.EventHandler(this.btnSaveMnuItem_Click);
            // 
            // chkUsing
            // 
            this.chkUsing.EditValue = true;
            this.chkUsing.Location = new System.Drawing.Point(5, 117);
            this.chkUsing.Name = "chkUsing";
            this.chkUsing.Properties.Caption = "启用";
            this.chkUsing.Size = new System.Drawing.Size(92, 19);
            this.chkUsing.TabIndex = 3;
            // 
            // txtmnuAsmName
            // 
            this.txtmnuAsmName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmnuAsmName.Location = new System.Drawing.Point(76, 91);
            this.txtmnuAsmName.Name = "txtmnuAsmName";
            this.txtmnuAsmName.Size = new System.Drawing.Size(406, 20);
            this.txtmnuAsmName.TabIndex = 2;
            // 
            // txtmnuClassName
            // 
            this.txtmnuClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmnuClassName.Location = new System.Drawing.Point(76, 64);
            this.txtmnuClassName.Name = "txtmnuClassName";
            this.txtmnuClassName.Size = new System.Drawing.Size(406, 20);
            this.txtmnuClassName.TabIndex = 1;
            // 
            // txtmnuName
            // 
            this.txtmnuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmnuName.Location = new System.Drawing.Point(76, 37);
            this.txtmnuName.Name = "txtmnuName";
            this.txtmnuName.Size = new System.Drawing.Size(406, 20);
            this.txtmnuName.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.Controls.Add(this.labelControl1);
            this.groupPanel2.Controls.Add(this.btnSaveMnuGrp);
            this.groupPanel2.Controls.Add(this.txtmnuGrp);
            this.groupPanel2.Location = new System.Drawing.Point(14, 25);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(487, 100);
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "菜单组";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "菜单组名称";
            // 
            // btnSaveMnuGrp
            // 
            this.btnSaveMnuGrp.Location = new System.Drawing.Point(5, 62);
            this.btnSaveMnuGrp.Name = "btnSaveMnuGrp";
            this.btnSaveMnuGrp.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMnuGrp.TabIndex = 1;
            this.btnSaveMnuGrp.Text = "保存修改";
            this.btnSaveMnuGrp.Click += new System.EventHandler(this.btnSaveMnuGrp_Click);
            // 
            // txtmnuGrp
            // 
            this.txtmnuGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmnuGrp.Location = new System.Drawing.Point(76, 35);
            this.txtmnuGrp.Name = "txtmnuGrp";
            this.txtmnuGrp.Size = new System.Drawing.Size(406, 20);
            this.txtmnuGrp.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barSubItem1,
            this.barBtnLogoff,
            this.barBtnExit,
            this.barStaticItem1,
            this.barLabel,
            this.barSubOpt,
            this.barSubItem3,
            this.barSkin,
            this.barSubItem2,
            this.barMnuTaobao,
            this.barChkSys,
            this.barChkTaobao,
            this.barBtnSysInfo,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barBtnSysMnu,
            this.barbtnMnuGrp,
            this.barbtnMnuItem,
            this.barbtnDel,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5});
            this.barManager1.MaxItemId = 26;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(732, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 448);
            this.barDockControlBottom.Size = new System.Drawing.Size(732, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 448);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(732, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 448);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "txx";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "系统(&S)";
            this.barSubItem1.Id = 1;
            this.barSubItem1.ImageIndex = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnLogoff),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnExit)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtnLogoff
            // 
            this.barBtnLogoff.Caption = "注销(&L)";
            this.barBtnLogoff.Id = 2;
            this.barBtnLogoff.ImageIndex = 1;
            this.barBtnLogoff.Name = "barBtnLogoff";
            // 
            // barBtnExit
            // 
            this.barBtnExit.Caption = "退出(&X)";
            this.barBtnExit.Id = 3;
            this.barBtnExit.ImageIndex = 2;
            this.barBtnExit.Name = "barBtnExit";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "当前登录用户:";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barLabel
            // 
            this.barLabel.Caption = " ";
            this.barLabel.Id = 5;
            this.barLabel.Name = "barLabel";
            this.barLabel.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barSubOpt
            // 
            this.barSubOpt.Caption = "设置(&S)";
            this.barSubOpt.Id = 6;
            this.barSubOpt.ImageIndex = 3;
            this.barSubOpt.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSkin),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSysMnu)});
            this.barSubOpt.Name = "barSubOpt";
            this.barSubOpt.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSkin
            // 
            this.barSkin.Caption = "外观";
            this.barSkin.Id = 8;
            this.barSkin.ImageIndex = 4;
            this.barSkin.Name = "barSkin";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "菜单样式";
            this.barSubItem2.Id = 10;
            this.barSubItem2.ImageIndex = 5;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barChkSys),
            new DevExpress.XtraBars.LinkPersistInfo(this.barChkTaobao)});
            this.barSubItem2.Name = "barSubItem2";
            this.barSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barChkSys
            // 
            this.barChkSys.Caption = "系统风格";
            this.barChkSys.Checked = true;
            this.barChkSys.Id = 13;
            this.barChkSys.Name = "barChkSys";
            // 
            // barChkTaobao
            // 
            this.barChkTaobao.Caption = "商家后台风格";
            this.barChkTaobao.Id = 14;
            this.barChkTaobao.Name = "barChkTaobao";
            // 
            // barBtnSysMnu
            // 
            this.barBtnSysMnu.Caption = "系统菜单";
            this.barBtnSysMnu.Id = 18;
            this.barBtnSysMnu.Name = "barBtnSysMnu";
            this.barBtnSysMnu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "帮助(&H)";
            this.barSubItem3.Id = 7;
            this.barSubItem3.ImageIndex = 6;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSysInfo)});
            this.barSubItem3.Name = "barSubItem3";
            this.barSubItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtnSysInfo
            // 
            this.barBtnSysInfo.Caption = "系统信息";
            this.barBtnSysInfo.Id = 15;
            this.barBtnSysInfo.Name = "barBtnSysInfo";
            // 
            // barMnuTaobao
            // 
            this.barMnuTaobao.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barMnuTaobao.Caption = "商家后台风格";
            this.barMnuTaobao.Id = 12;
            this.barMnuTaobao.Name = "barMnuTaobao";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "barStaticItem2";
            this.barStaticItem2.Id = 16;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "SvrTime";
            this.barStaticItem3.Id = 17;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barbtnMnuGrp
            // 
            this.barbtnMnuGrp.Caption = "添加菜单组";
            this.barbtnMnuGrp.Id = 19;
            this.barbtnMnuGrp.Name = "barbtnMnuGrp";
            this.barbtnMnuGrp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnMnuGrp_ItemClick);
            // 
            // barbtnMnuItem
            // 
            this.barbtnMnuItem.Caption = "添加菜单项";
            this.barbtnMnuItem.Id = 20;
            this.barbtnMnuItem.Name = "barbtnMnuItem";
            this.barbtnMnuItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnMnuItem_ItemClick);
            // 
            // barbtnDel
            // 
            this.barbtnDel.Caption = "删除";
            this.barbtnDel.Id = 21;
            this.barbtnDel.Name = "barbtnDel";
            this.barbtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnDel_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 22;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "加载最新菜单";
            this.barButtonItem3.Id = 23;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 24;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "导出菜单";
            this.barButtonItem5.Id = 25;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // popMenuCtl1
            // 
            this.popMenuCtl1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnMnuGrp),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnMnuItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.popMenuCtl1.Manager = this.barManager1;
            this.popMenuCtl1.Name = "popMenuCtl1";
            // 
            // fdlg
            // 
            this.fdlg.Filter = "*.xml|*.xml";
            this.fdlg.Title = "菜单导出";
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 448);
            this.Controls.Add(this.sptPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MenuView";
            this.Text = "系统菜单设置";
            this.Load += new System.EventHandler(this.MenuView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sptPanel1)).EndInit();
            this.sptPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel3)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuAsmName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel2)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtmnuGrp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenuCtl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl sptPanel1;
        private TreeList treeCtl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private GroupControl groupPanel1;
        private GroupControl groupPanel3;
        private GroupControl groupPanel2;
        private TextEdit txtmnuGrp;
        private TextEdit txtmnuClassName;
        private TextEdit txtmnuName;
        private SimpleButton btnSaveMnuGrp;
        private TextEdit txtmnuAsmName;
        private SimpleButton btnSaveMnuItem;
        private CheckEdit chkUsing;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barBtnLogoff;
        private DevExpress.XtraBars.BarButtonItem barBtnExit;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barLabel;
        private DevExpress.XtraBars.BarSubItem barSubOpt;
        private DevExpress.XtraBars.BarButtonItem barSkin;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarCheckItem barChkSys;
        private DevExpress.XtraBars.BarCheckItem barChkTaobao;
        private DevExpress.XtraBars.BarButtonItem barBtnSysMnu;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem barBtnSysInfo;
        private DevExpress.XtraBars.BarButtonItem barMnuTaobao;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarButtonItem barbtnMnuGrp;
        private DevExpress.XtraBars.BarButtonItem barbtnMnuItem;
        private DevExpress.XtraBars.BarButtonItem barbtnDel;
        private PopupMenu popMenuCtl1;
        private SimpleButton btnSaveToSvr;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private System.Windows.Forms.SaveFileDialog fdlg;
        private LabelControl labelControl4;
        private LabelControl labelControl3;
        private LabelControl labelControl2;
        private LabelControl labelControl1;

    }
}