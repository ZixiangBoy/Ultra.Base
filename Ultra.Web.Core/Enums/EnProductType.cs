using System;
using System.ComponentModel;

namespace Ultra.Web.Core.Enums
{
    [Description("产品类型描述")]
    public enum EnProductType
    {
        [Description("BI")]
        BI = 8,
        [Description("CRM")]
        CRM = 2,
        [Description("ERP")]
        ERP = 1,
        [Description("UnKnown")]
        UnKnown = 0,
        [Description("WWPlugin")]
        WWPlugin = 4
    }
}

