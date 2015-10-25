using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ultra.Web.Core.Common;

namespace Ultra.Surface.Common
{
    public static class MsgBox
    {
        public static DialogResult ShowMessage(string cap,string text)
        {
            if (string.IsNullOrEmpty(cap))
                cap = "提示";
            return XtraMessageBox.Show(text, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowYesNoMessage(string cap,string text)
        {
            if (string.IsNullOrEmpty(cap))
                cap = "提示";
            return XtraMessageBox.Show(text, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
   
}
