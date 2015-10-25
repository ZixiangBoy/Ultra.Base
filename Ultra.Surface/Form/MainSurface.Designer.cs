namespace Ultra.Surface.Form
{
    partial class MainSurface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSurface));
            this.baseBarMgr = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEdt = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnLock = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUnLock = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnInvalid = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRole = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRoleUsr = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExport = new DevExpress.XtraBars.BarSubItem();
            this.barBtnExportXls = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAudit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRefuse = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSubmit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUnAudit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPurche = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnInStock = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnGet = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRecv = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnMake = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAssign = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnForceAudit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSync = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnBatchUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEnable = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDisable = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barBtnUnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnApplyPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.baseBarMgr)).BeginInit();
            this.SuspendLayout();
            // 
            // baseBarMgr
            // 
            this.baseBarMgr.AllowQuickCustomization = false;
            this.baseBarMgr.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.baseBarMgr.DockControls.Add(this.barDockControlTop);
            this.baseBarMgr.DockControls.Add(this.barDockControlBottom);
            this.baseBarMgr.DockControls.Add(this.barDockControlLeft);
            this.baseBarMgr.DockControls.Add(this.barDockControlRight);
            this.baseBarMgr.Form = this;
            this.baseBarMgr.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnNew,
            this.barBtnEdt,
            this.barBtnRefresh,
            this.barBtnDel,
            this.barBtnImport,
            this.barBtnExport,
            this.barBtnExportXls,
            this.barBtnAudit,
            this.barBtnRefuse,
            this.barBtnSubmit,
            this.barBtnUnAudit,
            this.barBtnLock,
            this.barBtnRole,
            this.barBtnUnLock,
            this.barBtnInvalid,
            this.barBtnPrint,
            this.barBtnRoleUsr,
            this.barBtnPurche,
            this.barBtnInStock,
            this.barBtnGet,
            this.barBtnRecv,
            this.barBtnMake,
            this.barBtnAssign,
            this.barBtnForceAudit,
            this.barBtnBatchUpdate,
            this.barBtnEnable,
            this.barBtnDisable,
            this.barBtnSync,
            this.barBtnRestore,
            this.barBtnUnPrint,
            this.barBtnApplyPrint,
            this.barBtnPrintPreview});
            this.baseBarMgr.MaxItemId = 32;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnRefresh, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnNew, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnEdt, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnDel, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnLock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnUnLock, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnEnable, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnDisable, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnAudit, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnInvalid, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnUnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnApplyPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrintPreview),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnRole, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnRoleUsr, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnImport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnRefuse, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnSubmit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnUnAudit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPurche, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnInStock, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnGet, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRecv, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnMake, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnAssign, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnForceAudit, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnSync, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnBatchUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnRestore, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.Text = "Tools";
            // 
            // barBtnRefresh
            // 
            this.barBtnRefresh.Caption = "刷新(&R)";
            this.barBtnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRefresh.Glyph")));
            this.barBtnRefresh.Id = 2;
            this.barBtnRefresh.ImageIndex = 6;
            this.barBtnRefresh.Name = "barBtnRefresh";
            this.barBtnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnRefresh.Tag = "刷新";
            // 
            // barBtnNew
            // 
            this.barBtnNew.Caption = "新增(&N)";
            this.barBtnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnNew.Glyph")));
            this.barBtnNew.Id = 0;
            this.barBtnNew.ImageIndex = 0;
            this.barBtnNew.Name = "barBtnNew";
            this.barBtnNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnNew.Tag = "新增";
            this.barBtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnEdt
            // 
            this.barBtnEdt.Caption = "修改(&E)";
            this.barBtnEdt.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnEdt.Glyph")));
            this.barBtnEdt.Id = 1;
            this.barBtnEdt.ImageIndex = 2;
            this.barBtnEdt.Name = "barBtnEdt";
            this.barBtnEdt.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnEdt.Tag = "修改";
            this.barBtnEdt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnLock
            // 
            this.barBtnLock.Caption = "锁定(&L)";
            this.barBtnLock.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnLock.Glyph")));
            this.barBtnLock.Id = 11;
            this.barBtnLock.ImageIndex = 19;
            this.barBtnLock.Name = "barBtnLock";
            this.barBtnLock.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnLock.Tag = "锁定";
            this.barBtnLock.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnUnLock
            // 
            this.barBtnUnLock.Caption = "解锁(&K)";
            this.barBtnUnLock.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnUnLock.Glyph")));
            this.barBtnUnLock.Id = 13;
            this.barBtnUnLock.ImageIndex = 22;
            this.barBtnUnLock.Name = "barBtnUnLock";
            this.barBtnUnLock.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnUnLock.Tag = "解锁";
            this.barBtnUnLock.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnInvalid
            // 
            this.barBtnInvalid.Caption = "作废(&Z)";
            this.barBtnInvalid.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnInvalid.Glyph")));
            this.barBtnInvalid.Id = 14;
            this.barBtnInvalid.ImageIndex = 23;
            this.barBtnInvalid.Name = "barBtnInvalid";
            this.barBtnInvalid.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnInvalid.Tag = "作废";
            this.barBtnInvalid.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnDel
            // 
            this.barBtnDel.Caption = "删除(&D)";
            this.barBtnDel.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDel.Glyph")));
            this.barBtnDel.Id = 3;
            this.barBtnDel.ImageIndex = 4;
            this.barBtnDel.Name = "barBtnDel";
            this.barBtnDel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnDel.Tag = "删除";
            this.barBtnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnPrint
            // 
            this.barBtnPrint.Caption = "打印(&P)";
            this.barBtnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnPrint.Glyph")));
            this.barBtnPrint.Id = 15;
            this.barBtnPrint.ImageIndex = 24;
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnPrint.Tag = "打印";
            this.barBtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnRole
            // 
            this.barBtnRole.Caption = "用户权限(&T)";
            this.barBtnRole.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRole.Glyph")));
            this.barBtnRole.Id = 12;
            this.barBtnRole.ImageIndex = 21;
            this.barBtnRole.Name = "barBtnRole";
            this.barBtnRole.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnRole.Tag = "用户权限";
            this.barBtnRole.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnRoleUsr
            // 
            this.barBtnRoleUsr.Caption = "角色用户(L)";
            this.barBtnRoleUsr.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRoleUsr.Glyph")));
            this.barBtnRoleUsr.Id = 16;
            this.barBtnRoleUsr.ImageIndex = 25;
            this.barBtnRoleUsr.Name = "barBtnRoleUsr";
            this.barBtnRoleUsr.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnRoleUsr.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnImport
            // 
            this.barBtnImport.Caption = "导入(&I)";
            this.barBtnImport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnImport.Glyph")));
            this.barBtnImport.Id = 4;
            this.barBtnImport.ImageIndex = 10;
            this.barBtnImport.Name = "barBtnImport";
            this.barBtnImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnImport.Tag = "导入";
            this.barBtnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnExport
            // 
            this.barBtnExport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnExport.Glyph")));
            this.barBtnExport.Id = 5;
            this.barBtnExport.ImageIndex = 8;
            this.barBtnExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnExportXls)});
            this.barBtnExport.Name = "barBtnExport";
            this.barBtnExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnExport.Tag = "导出";
            this.barBtnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnExportXls
            // 
            this.barBtnExportXls.Caption = "导出到EXCEL";
            this.barBtnExportXls.Id = 6;
            this.barBtnExportXls.ImageIndex = 12;
            this.barBtnExportXls.Name = "barBtnExportXls";
            this.barBtnExportXls.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnExportXls.Tag = "导出到EXCEL";
            this.barBtnExportXls.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnAudit
            // 
            this.barBtnAudit.Caption = "审核(&A)";
            this.barBtnAudit.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnAudit.Glyph")));
            this.barBtnAudit.Id = 7;
            this.barBtnAudit.ImageIndex = 14;
            this.barBtnAudit.Name = "barBtnAudit";
            this.barBtnAudit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnAudit.Tag = "审核";
            this.barBtnAudit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnRefuse
            // 
            this.barBtnRefuse.Caption = "驳回(&F)";
            this.barBtnRefuse.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRefuse.Glyph")));
            this.barBtnRefuse.Id = 8;
            this.barBtnRefuse.ImageIndex = 16;
            this.barBtnRefuse.Name = "barBtnRefuse";
            this.barBtnRefuse.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnRefuse.Tag = "驳回";
            this.barBtnRefuse.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnSubmit
            // 
            this.barBtnSubmit.Caption = "提交(&S)";
            this.barBtnSubmit.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSubmit.Glyph")));
            this.barBtnSubmit.Id = 9;
            this.barBtnSubmit.ImageIndex = 17;
            this.barBtnSubmit.Name = "barBtnSubmit";
            this.barBtnSubmit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSubmit.Tag = "提交";
            this.barBtnSubmit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnUnAudit
            // 
            this.barBtnUnAudit.Caption = "退审(&U)";
            this.barBtnUnAudit.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnUnAudit.Glyph")));
            this.barBtnUnAudit.Id = 10;
            this.barBtnUnAudit.ImageIndex = 18;
            this.barBtnUnAudit.Name = "barBtnUnAudit";
            this.barBtnUnAudit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnUnAudit.Tag = "退审";
            this.barBtnUnAudit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnPurche
            // 
            this.barBtnPurche.Caption = "采购";
            this.barBtnPurche.Id = 17;
            this.barBtnPurche.ImageIndex = 26;
            this.barBtnPurche.Name = "barBtnPurche";
            this.barBtnPurche.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnPurche.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnInStock
            // 
            this.barBtnInStock.Caption = "入库";
            this.barBtnInStock.Id = 18;
            this.barBtnInStock.ImageIndex = 28;
            this.barBtnInStock.Name = "barBtnInStock";
            this.barBtnInStock.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnInStock.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnGet
            // 
            this.barBtnGet.Caption = "获取";
            this.barBtnGet.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnGet.Glyph")));
            this.barBtnGet.Id = 19;
            this.barBtnGet.ImageIndex = 27;
            this.barBtnGet.Name = "barBtnGet";
            this.barBtnGet.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnGet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnRecv
            // 
            this.barBtnRecv.Caption = "领取";
            this.barBtnRecv.Id = 20;
            this.barBtnRecv.ImageIndex = 29;
            this.barBtnRecv.Name = "barBtnRecv";
            this.barBtnRecv.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnRecv.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnMake
            // 
            this.barBtnMake.Caption = "生产";
            this.barBtnMake.Id = 21;
            this.barBtnMake.ImageIndex = 30;
            this.barBtnMake.Name = "barBtnMake";
            this.barBtnMake.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnMake.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnAssign
            // 
            this.barBtnAssign.Caption = "分配";
            this.barBtnAssign.Id = 22;
            this.barBtnAssign.ImageIndex = 31;
            this.barBtnAssign.Name = "barBtnAssign";
            this.barBtnAssign.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnAssign.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnForceAudit
            // 
            this.barBtnForceAudit.Caption = "强制审核";
            this.barBtnForceAudit.Id = 23;
            this.barBtnForceAudit.ImageIndex = 32;
            this.barBtnForceAudit.Name = "barBtnForceAudit";
            this.barBtnForceAudit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnForceAudit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnSync
            // 
            this.barBtnSync.Caption = "同步";
            this.barBtnSync.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSync.Glyph")));
            this.barBtnSync.Id = 27;
            this.barBtnSync.ImageIndex = 36;
            this.barBtnSync.Name = "barBtnSync";
            this.barBtnSync.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSync.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnBatchUpdate
            // 
            this.barBtnBatchUpdate.Caption = "批量修改";
            this.barBtnBatchUpdate.Id = 24;
            this.barBtnBatchUpdate.ImageIndex = 33;
            this.barBtnBatchUpdate.Name = "barBtnBatchUpdate";
            this.barBtnBatchUpdate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnBatchUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnEnable
            // 
            this.barBtnEnable.Caption = "启用";
            this.barBtnEnable.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnEnable.Glyph")));
            this.barBtnEnable.Id = 25;
            this.barBtnEnable.ImageIndex = 35;
            this.barBtnEnable.Name = "barBtnEnable";
            this.barBtnEnable.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnEnable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnDisable
            // 
            this.barBtnDisable.Caption = "禁用";
            this.barBtnDisable.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDisable.Glyph")));
            this.barBtnDisable.Id = 26;
            this.barBtnDisable.ImageIndex = 34;
            this.barBtnDisable.Name = "barBtnDisable";
            this.barBtnDisable.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnDisable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnRestore
            // 
            this.barBtnRestore.Caption = "还原";
            this.barBtnRestore.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRestore.Glyph")));
            this.barBtnRestore.Id = 28;
            this.barBtnRestore.ImageIndex = 37;
            this.barBtnRestore.Name = "barBtnRestore";
            this.barBtnRestore.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1348, 137);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 485);
            this.barDockControlBottom.Size = new System.Drawing.Size(1348, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 137);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 348);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1348, 137);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 348);
            // 
            // barBtnUnPrint
            // 
            this.barBtnUnPrint.Caption = "退打印";
            this.barBtnUnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnUnPrint.Glyph")));
            this.barBtnUnPrint.Id = 29;
            this.barBtnUnPrint.Name = "barBtnUnPrint";
            this.barBtnUnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnApplyPrint
            // 
            this.barBtnApplyPrint.Caption = "申请打印";
            this.barBtnApplyPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnApplyPrint.Glyph")));
            this.barBtnApplyPrint.Id = 30;
            this.barBtnApplyPrint.Name = "barBtnApplyPrint";
            this.barBtnApplyPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnPrintPreview
            // 
            this.barBtnPrintPreview.Caption = "打印预览";
            this.barBtnPrintPreview.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnPrintPreview.Glyph")));
            this.barBtnPrintPreview.Id = 31;
            this.barBtnPrintPreview.Name = "barBtnPrintPreview";
            this.barBtnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // MainSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 485);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MainSurface";
            this.Text = "MainSurface";
            ((System.ComponentModel.ISupportInitialize)(this.baseBarMgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraBars.Bar bar1;
        public DevExpress.XtraBars.BarDockControl barDockControlTop;
        public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        public DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarManager baseBarMgr;
        public DevExpress.XtraBars.BarButtonItem barBtnNew;
        public DevExpress.XtraBars.BarButtonItem barBtnEdt;
        public DevExpress.XtraBars.BarButtonItem barBtnRefresh;
        public DevExpress.XtraBars.BarButtonItem barBtnDel;
        public DevExpress.XtraBars.BarButtonItem barBtnImport;
        public DevExpress.XtraBars.BarSubItem barBtnExport;
        public DevExpress.XtraBars.BarButtonItem barBtnExportXls;
        public DevExpress.XtraBars.BarButtonItem barBtnAudit;
        public DevExpress.XtraBars.BarButtonItem barBtnRefuse;
        public DevExpress.XtraBars.BarButtonItem barBtnSubmit;
        public DevExpress.XtraBars.BarButtonItem barBtnUnAudit;
        public DevExpress.XtraBars.BarButtonItem barBtnLock;
        public DevExpress.XtraBars.BarButtonItem barBtnRole;
        public DevExpress.XtraBars.BarButtonItem barBtnUnLock;
        public DevExpress.XtraBars.BarButtonItem barBtnInvalid;
        private DevExpress.XtraBars.BarButtonItem barBtnPrint;
        public DevExpress.XtraBars.BarButtonItem barBtnRoleUsr;
        public DevExpress.XtraBars.BarButtonItem barBtnInStock;
        public DevExpress.XtraBars.BarButtonItem barBtnPurche;
        public DevExpress.XtraBars.BarButtonItem barBtnGet;
        public DevExpress.XtraBars.BarButtonItem barBtnAssign;
        public DevExpress.XtraBars.BarButtonItem barBtnRecv;
        public DevExpress.XtraBars.BarButtonItem barBtnMake;
        public DevExpress.XtraBars.BarButtonItem barBtnForceAudit;
        public DevExpress.XtraBars.BarButtonItem barBtnBatchUpdate;
        public DevExpress.XtraBars.BarButtonItem barBtnEnable;
        public DevExpress.XtraBars.BarButtonItem barBtnDisable;
        public DevExpress.XtraBars.BarButtonItem barBtnSync;
        public DevExpress.XtraBars.BarButtonItem barBtnRestore;
        private DevExpress.XtraBars.BarButtonItem barBtnUnPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnApplyPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnPrintPreview;
    }
}