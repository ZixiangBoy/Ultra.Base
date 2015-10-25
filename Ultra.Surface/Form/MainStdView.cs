using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ultra.Surface.Form
{
    /// <summary>
    /// 标准浏览画面基类
    /// </summary>
    public partial class MainStdView : MainSurface
    {
        public MainStdView():base()
        {
            InitializeComponent();
            dpQuery.ClosingPanel += dpQuery_ClosingPanel;
        }

        void dpQuery_ClosingPanel(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
            if (dpQuery.Dock == DevExpress.XtraBars.Docking.DockingStyle.Float)
                dpQuery.DockTo(DevExpress.XtraBars.Docking.DockingStyle.Top);
            dpQuery.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            dpQuery.HideImmediately();
        }
    }
}
