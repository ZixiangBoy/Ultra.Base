using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ultra.Surface.Common
{
    /// <summary>
    /// 菜单项实体数据定义
    /// </summary>
    [Serializable]
    public class MenuData
    {
        public string MenuGrpName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUsing { get; set; }

        /// <summary>
        /// 菜单数据
        /// </summary>
        public List<MenuItemData> MenuItems { get; set; }
    }

    [Serializable]
    public class MenuItemData
    {
        /// <summary>
        /// 菜单名
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单类名
        /// </summary>
        public string MenuClsName { get; set; }

        /// <summary>
        /// 菜单程序集名
        /// </summary>
        public string MenuAsmName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUsing { get; set; }

        public object Extra { get; set; }

        ///// <summary>
        ///// 控件权限控制
        ///// </summary>
        //public List<MenuCtlData> CtlData { get; set; }
    }

    public enum EnCtlType : int
    {
        Undefine = 0,

        /// <summary>
        /// 工具栏
        /// </summary>
        [Description("主按钮")]
        ToolBarItems = 1,

        /// <summary>
        /// 网格
        /// </summary>
        [Description("网格")]
        Grids = 2,

        /// <summary>
        /// 弹出窗口
        /// </summary>
        [Description("弹出窗口")]
        DialogForms = 3,

        /// <summary>
        /// 自定义按钮
        /// </summary>
        [Description("自定义按钮")]
        ButtonItems = 4,

        /// <summary>
        /// 网格列
        /// </summary>
        [Description("网格列")]
        GridCol = 5,
    }

    [Serializable]
    public class MenuCtlData
    {
        public EnCtlType CtlType { get; set; }
        public string ControlName { get; set; }
        public bool IsEnabled { get; set; }
        public string TextName { get; set; }
        public string ClsName { get; set; }
        public string AsmName { get; set; }
        public string AsmMD5 { get; set; }
        public string ParentCtlName { get; set; }
        public string MenuGrpName { get; set; }
        public string MenuName { get; set; }
    }
}
