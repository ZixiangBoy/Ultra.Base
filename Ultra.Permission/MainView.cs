using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Lanuch;
using Ultra.Web.Core.Common;
using Ultra.Surface.Extend;
using DbEntity;
using PetaPoco;
using Ultra.Surface.Interfaces;
using DevExpress.XtraBars;
using Ultra.Surface.Common;

namespace Ultra.Permission {
    public partial class MainView : BaseForm, Ultra.Surface.Interfaces.ISurfacePermission {
        public MainView() {
            InitializeComponent();
        }

        #region ISurfacePermission 成员

        public List<Control> ButtonItems {
            get { return null; }
        }

        public List<Ultra.Surface.Form.BaseSurface> DialogForms {
            get { return null; }
        }

        public List<Ultra.Surface.Interfaces.PermitGridView> Grids {
            get {
                return new List<PermitGridView>(){
                    new PermitGridView(gridView1,"权限信息"),                    
                    new PermitGridView(gridView2,"用户信息")
                };
            }
        }

        public List<Control> MenuItems {
            get { return null; }
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<BarButtonItem>() { 
                    myBar.btnRefresh,
                    myBar.btnAuthorPur,
                    myBar.btnAuthorUser,
                    myBar.btnExport
                };
            }
        }

        #endregion

        private void MainView_Load(object sender, EventArgs e) {
            var usr = GetCurUser<t_user>();
            this.myBar.btnRefresh.ItemClick += barBtnRefresh_ItemClick;
            if (usr.UserName.IgnoreCaseEqual("admin"))
                this.myBar.btnAuthorUser.Visibility =
                    this.myBar.btnAuthorPur.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.myBar.btnAuthorUser.ItemClick += barBtnRoleUsr_ItemClick;
            this.myBar.btnAuthorPur.ItemClick += barBtnRole_ItemClick;
            myBar.btnExport.ItemClick += btnExport_ItemClick;
        }

        void btnExport_ItemClick(object sender, ItemClickEventArgs e) {
            var role = gridControlEx1.GetFocusedDataSource<t_role>();
            if (role == null)
                return;
            var rolepremts = Db.Fetch<t_rolepermit>(" where RoleId=@0", role.Id);
            foreach (var j in rolepremts) {
                j.AsmName = j.CtlType == (int)EnCtlType.ToolBarItems ?
                    "主按钮" : (j.CtlType == (int)EnCtlType.Grids ? "网格" : (j.CtlType == (int)EnCtlType.GridCol ? "网格列" : (j.CtlType == (int)EnCtlType.ButtonItems ? "自定义按钮" : "其他")));
                j.AsmMD5 = j.IsEnabled ? "是" : "否";
            }
            var vw = new PermitViewExport();
            vw.gridControlEx1.DataSource = rolepremts;
            var fdlg = new SaveFileDialog();
            fdlg.Filter = "*.xlsx|*.xlsx";
            if (fdlg.ShowDialog() == DialogResult.OK) {
                vw.gridControlEx1.ExportToXlsx(fdlg.FileName);
                if (MsgBox.ShowYesNoMessage("导出成功", "导出成功,是否立即打开?") == DialogResult.Yes) {
                    SystemInvoke.OpenFile(fdlg.FileName);
                }
            }
        }

        void barBtnRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new PermitView();
            vw.EditMode = Ultra.Web.Core.Enums.EnViewEditMode.Edit;
            Lanucher.InitView(vw);
            vw.ShowDialog();
        }

        void barBtnRoleUsr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new NewView();
            vw.EditMode = Ultra.Web.Core.Enums.EnViewEditMode.Edit;
            Lanucher.InitView(vw);
            vw.ShowDialog();
            gridView1_FocusedRowChanged(sender, null);
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.gridControlEx1.DataSource = Db.Fetch<t_role>(" where IsUsing=1");
            this.gridControlEx1.ReleaseFocusedRow();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var et = this.gridControlEx1.GetFocusedDataSource<t_role>();
            if (null == et) {
                this.gridControlEx2.DataSource = null;
                return;
            }
            var users = Db.Query<t_user>("Select * from t_user");
            var rus = Db.Query<t_roleuser>("Select * from t_roleuser");
            var op = (from o in users
                      join k in rus.Where(t => t.RoleId == et.Id)
                          on o.Id equals k.UserId

                      select o);

            this.gridControlEx2.DataSource = op.ToList();
        }
    }
}
