using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Extend;
using Ultra.Surface.Common;
using Ultra.Surface.Lanuch;
using DbEntity;
using System.Data.SqlClient;
using Ultra.Web.Core.Common;
using PetaPoco;


namespace Ultra.Role
{
    public partial class MainView : BaseForm, Ultra.Surface.Interfaces.ISurfacePermission
    {

        #region ISurfacePermission 成员

        public List<Control> ButtonItems
        {
            get { return null; }
        }

        public List<Ultra.Surface.Form.BaseSurface> DialogForms
        {
            get { return null; }
        }

        public List<Ultra.Surface.Interfaces.PermitGridView> Grids
        {
            get
            {
                return new List<Ultra.Surface.Interfaces.PermitGridView> { 
                new Ultra.Surface.Interfaces.PermitGridView(this.gridView1,"角色信息")
            };
            }
        }

        public List<Control> MenuItems
        {
            get { return null; }
        }

        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems
        {
            get
            {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                this.myBar.btnModify,
                this.myBar.btnCreate,
                this.myBar.btnRemove,
                this.myBar.btnRefresh
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
            this.myBar.btnCreate.ItemClick += barBtnNew_ItemClick;
            this.myBar.btnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.myBar.btnModify.ItemClick += barBtnEdt_ItemClick;
            this.myBar.btnRemove.ItemClick += barBtnDel_ItemClick;
        }


        void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridControlEx1.GetFocusedDataSource<t_role>();

            if (et == null) return;
            if (MsgBox.ShowYesNoMessage(null, "确定要删除吗?") == System.Windows.Forms.DialogResult.No)
                return;
            SqlHelper.ExecuteNonQuery(ConnString,System.Data.CommandType.Text,"delete from t_role where Guid=@Guid",
                new SqlParameter("@Guid", et.Guid)
                );
            barBtnRefresh_ItemClick(sender, e);
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var et = gridControlEx1.GetFocusedDataSource<t_role>();
            if (null == et) return;
            var vw = new NewView();
            vw.EditMode = Ultra.Web.Core.Enums.EnViewEditMode.Edit;
            vw.GuidKey = et.Guid;
            Lanucher.InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(sender, e);
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var db = new Database())
            {
                this.gridControlEx1.DataSource = db.Fetch<t_role>("select * from t_role");
            }
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var vw = new NewView();
            vw.EditMode = Ultra.Web.Core.Enums.EnViewEditMode.New;
            Lanucher.InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                barBtnRefresh_ItemClick(sender, e);
            }
        }
    }
}
