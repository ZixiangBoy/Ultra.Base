using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Form;

namespace Ultra.Surface.Interfaces
{
    /// <summary>
    /// UI 权限控制接口
    /// </summary>
    public interface ISurfacePermission
    {
        /// <summary>
        /// 有权限操作的工具栏按钮集合
        /// </summary>
        List<DevExpress.XtraBars.BarButtonItem> ToolBarItems { get; }

        /// <summary>
        /// 有权限操作的按钮集合
        /// </summary>
        List<Control> ButtonItems { get; }

        /// <summary>
        /// 有权限操作的菜单集合
        /// </summary>
        List<Control> MenuItems { get; }

        /// <summary>
        /// 有操作权限的GridView
        /// </summary>
        List<PermitGridView> Grids { get; }

        /// <summary>
        /// 画面的内弹出对话框
        /// </summary>
        List<BaseSurface> DialogForms { get; }
    }

    public partial class PermitGridView
    {
        public PermitGridView(DevExpress.XtraGrid.Views.Grid.GridView gv){
            this.Gv=gv;
        }

        public PermitGridView(DevExpress.XtraGrid.Views.Grid.GridView gv,string name):this(gv){
            this._Name=name;
        }

        private string _Name=string.Empty;

        public DevExpress.XtraGrid.Views.Grid.GridView Gv{get;set;}

        public string Name
        {
            get
            {
                if(string.IsNullOrEmpty(_Name))
                  return  _Name=null==Gv?_Name:Gv.Tag.ToString();
                return _Name;
            }
        }

    }
}
