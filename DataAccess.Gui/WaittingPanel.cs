using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataAccess.Gui
{
    public partial class WaittingPanel : UserControl
    {
        public WaittingPanel()
        {
            InitializeComponent();
        }
        bool u1 = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MarqueBar.Value >= MarqueBar.MaxValue) { u1 = false; }
            if (MarqueBar.Value <= MarqueBar.MinValue) { u1 = true; }

            if (u1) { MarqueBar.Value += 1; } else { MarqueBar.Value -= 1; }
        }

        [Category("Properties")]
        [Description("指定等待提示信息")]
        public string Message
        {
            get
            {
                return lblmsg.Text;
            }
            set
            {
                lblmsg.Text=value;
            }
        }

        [Category("Properties")]
        [Description("指定是否自动滚动")]
        public bool AutoMarquee
        {
            get { return this.timer1.Enabled; }
            set { this.timer1.Enabled = value; }
        }
    }
}
