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
using Ultra.Surface.Extend;
using Ultra.Web.Core.Common;
using Ultra.Surface.Common;
using PetaPoco;
using DbEntity;
using System.Data.SqlClient;


namespace Ultra.LoginBind {
    public partial class MainView : BaseForm, Ultra.Surface.Interfaces.ISurfacePermission {
        public MainView() {
            InitializeComponent();
        }

        #region ISurfacePermission 成员

        public List<Control> ButtonItems {
            get;
            set;
        }

        public List<BaseSurface> DialogForms {
            get;
            set;
        }

        public List<Ultra.Surface.Interfaces.PermitGridView> Grids {
            get {
                return new List<Ultra.Surface.Interfaces.PermitGridView>{
                    new Ultra.Surface.Interfaces.PermitGridView(this.gridView1,"已绑定MAC"),
                    new Ultra.Surface.Interfaces.PermitGridView(this.gridView2,"当前登录MAC"),
                    new Ultra.Surface.Interfaces.PermitGridView(this.gridView3,"未授权MAC")
                };
            }
        }

        public List<Control> MenuItems {
            get;
            set;
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                    this.myBar.btnModify,
                 this.myBar.btnReView,
                 this.myBar.btnRefresh,
                 this.myBar.btnRemove
            };
            }
        }

        #endregion

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            if (xtraTabControl1.SelectedTabPage == tpmac) {
                myBar.btnModify.Enabled = true;
                this.myBar.btnRemove.Enabled = true;
                myBar.btnReView.Enabled = false;
            } else if (xtraTabControl1.SelectedTabPage == tplogin) {
                myBar.btnModify.Enabled = false;
                this.myBar.btnRemove.Enabled = false;
                myBar.btnReView.Enabled = false;
            } else {
                myBar.btnModify.Enabled = false;
                this.myBar.btnRemove.Enabled = false;
                myBar.btnReView.Enabled = true;
            }
        }

        private void MainView_Load(object sender, EventArgs e) {
            this.myBar.btnRefresh.ItemClick += btnRefresh_ItemClick;
            this.myBar.btnReView.ItemClick += btnReView_ItemClick;
            this.myBar.btnModify.ItemClick += btnModify_ItemClick;
            this.myBar.btnRemove.ItemClick += btnRemove_ItemClick;
        }

        void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcMac.GetFocusedDataSource<t_mac>();
            if (null == et)
                return;
            if (MsgBox.ShowYesNoMessage(null, "确定要删除吗?") == System.Windows.Forms.DialogResult.No)
                return;
            using (var db = new Database()) {
                db.Delete(et);
            }
            using (var db = new Database()) {
                var etmac = db.Fetch<t_mac>("select * from t_mac");
                gcMac.DataSource = etmac;
            }
        }

        void btnModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //var et = gcMac.GetFocusedDataSource<t_fac_auditmac>();
            //if (null == et) return;
            var vw = new EditView();
            vw.EditMode = Ultra.Web.Core.Enums.EnViewEditMode.Edit;
            Lanucher.InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                using (var db = new Database()) {
                    var etmac = db.Fetch<t_mac>("select * from t_mac").OrderByDescending(k => k.Id).ToList();
                    gcMac.DataSource = etmac;
                }
            }
        }

        private string sql_addmac {
            get {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into t_mac(Guid,MAC,Creator,IsUsing)               \n");
                sb.Append("	select top 1 newid(),@0,@1,1 from t_user              \n");
                sb.Append("	where not exists(select 1 from t_mac where MAC=@1 ) \n");
                return sb.ToString();
            }
        }

        void btnReView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gcloginfail.GetFocusedDataSource<t_loginfail>();
            if (null == et)
                return;
            if (MsgBox.ShowYesNoMessage(null,
                string.Format("确定要将 {0} MAC:{1} 审核通过吗?", et.UserName, et.LoginMAC)) == System.Windows.Forms.DialogResult.No)
                return;
            var usr = GetCurUser<t_user>();
            using (var db = new Database()) {
                try {
                    db.BeginTransaction();
                    db.Delete("t_loginfail", "Id", et, et.Id);
                    db.Execute(sql_addmac, et.LoginMAC, usr.UserName, usr.Guid);
                    db.CompleteTransaction();
                } catch (Exception) {
                    db.AbortTransaction();
#if DEBUG
                    throw;
#endif
                }
            }
            using (var db = new Database()) {
                var etfail = db.Fetch<t_loginfail>("select * from t_loginfail");
                gcloginfail.DataSource = etfail;
                gcloginfail.RefreshDataSource();
                var etmac = db.Fetch<t_loginfail>("select * from t_mac");
                gcMac.DataSource = etmac;
                gcMac.RefreshDataSource();
            }
        }

        void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using (var db = new Database()) {
                var etmac = db.Fetch<t_mac>("select * from t_mac");
                gcMac.DataSource = etmac;
                //var etlogin = ctx.t_fac_logincur.ToList();
                //gclogincur.DataSource = etlogin;
                var etfail = db.Fetch<t_loginfail>("select * from t_loginfail");
                gcloginfail.DataSource = etfail;
            }
            using (var db = new Database()) {
                gclogincur.DataSource = db.Fetch<t_logincur>("where DATEDIFF(MINUTE,LastUpdateTime,getdate())<=2");
            }
        }

        private void gridView2_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                popupMenu1.ShowPopup(new Point() { X = MousePosition.X, Y = MousePosition.Y });
            }
        }

        private void barBtnForcedOffline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var rows = gridView2.GetSelectedRows();
            if (rows.Length <= 0)
                return;
            var offlines = new List<t_forcedoffline>();
            foreach (var r in rows) {
                var et=gridView2.GetRow(r) as t_logincur;
                if(et==null) continue;
                offlines.Add(new t_forcedoffline() {
                    LoginMAC = et.LoginMAC
                });
            }
            if (offlines.Count <= 0)
                return;
            try {
                using (var blk = new SqlBulkCopy(ConnString)) {
                    blk.DestinationTableName = "t_forcedoffline";
                    blk.WriteToServer<t_forcedoffline>(offlines);
                }
                MsgBox.ShowMessage("", string.Format("成功添加{0}台客户端!",offlines.Count));
            } catch (Exception) {
                
            }
        }

        private string Sql_AddForcedOffline {
            get {
                return
@"
INSERT INTO t_forcedoffline
(LoginMAC) Values(@LoginMAC)
";
            }
        }
    }
}
