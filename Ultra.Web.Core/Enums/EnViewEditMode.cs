using System;
using System.ComponentModel;

namespace Ultra.Web.Core.Enums
{
    [Description("画面编辑模式")]
    public enum EnViewEditMode
    {
        [Description("修改模式")]
        Edit = 2,
        [Description("新增模式")]
        New = 1,
        [Description("未定义")]
        UnDefine = 0,
        [Description("只读查看模式")]
        View = 3
    }
}

