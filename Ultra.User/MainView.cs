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
using Ultra.Surface.Common;
using Ultra.Web.Core.Common;
using DbEntity;
using System.Data.SqlClient;
using PetaPoco;
using DevExpress.XtraBars;

namespace Ultra.User
{
    public partial class MainView : BaseForm, Ultra.Surface.Interfaces.ISurfacePermission
    {
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
                return new List<Ultra.Surface.Interfaces.PermitGridView> { 
                new Ultra.Surface.Interfaces.PermitGridView(this.gridView1,"用户信息")
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
                    this.myBar.btnCreate,
                    this.myBar.btnModify,
                    this.myBar.btnRefresh,
                    this.myBar.btnExport,
                    myBar.btnRemove
                };
            }
        }

        #endregion

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            myBar.btnCreate.ItemClick += barBtnNew_ItemClick;
            myBar.btnRefresh.ItemClick += barBtnRefresh_ItemClick;
            myBar.btnModify.ItemClick += barBtnEdt_ItemClick;
            myBar.btnRemove.ItemClick += barBtnDel_ItemClick;
            myBar.btnExport.ItemClick += barBtnExport_ItemClick;
        }

        void barBtnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridControlEx1.GridExportXls();
        }

        void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridControlEx1.GetFocusedDataSource<t_user>();
            if (null == et) return;
            if (et.UserName.IgnoreCaseEqual("admin"))
            {
                MsgBox.ShowMessage("", "不允许删除系统管理员!"); return;
            }
            if (MsgBox.ShowYesNoMessage(null, "确定要删除吗?") == System.Windows.Forms.DialogResult.No)
                return;
            SqlHelper.ExecuteNonQuery(ConnString, System.Data.CommandType.Text, "delete from t_user where Guid=@Guid",
                new SqlParameter("@Guid", et.Guid)
                );
            barBtnRefresh_ItemClick(sender, e);
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControlEx1_RowCellDoubleClick(sender, null);
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var db = new Database())
            {
                this.gridControlEx1.DataSource = db.Fetch<t_user>("select * from t_user");
            }
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new NewView();
            Lanucher.InitView(vw);
            vw.EditMode = Ultra.Web.Core.Enums.EnViewEditMode.New;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(sender, e);
            }
        }

        private void gridControlEx1_RowCellDoubleClick(object sender, MouseEventArgs e)
        {
            var et = gridControlEx1.GetFocusedDataSource<t_user>();
            if (null == et) return;
            var vw = new NewView();
            Lanucher.InitView(vw);
            vw.EditMode = Ultra.Web.Core.Enums.EnViewEditMode.Edit;
            vw.GuidKey = et.Guid;
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                barBtnRefresh_ItemClick(sender, null);
        }
    }
}
