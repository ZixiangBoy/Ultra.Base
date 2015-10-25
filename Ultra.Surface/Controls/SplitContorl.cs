using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ultra.Surface.Controls
{
    public class SplitContorl : SplitterControl
    {

        public SplitContorl()
            : base()
        {
            this.Click += SplitContorl_Click;
        }
        private bool IsShow = true;

        /// <summary>
        /// 标签文本
        /// </summary>
        [Description("ShowGroupControl"),
        Browsable(true),
        Category("Ultra")]
        public GroupControl gb
        {
            get;
            set;
        }

        /// <summary>
        /// 标签文本
        /// </summary>
        [Description("ShowGroupControl"),
        Browsable(true),
        Category("Ultra")]
        public PanelControl Panap
        {
            get;
            set;
        }

        void SplitContorl_Click(object sender, EventArgs e)
        {
            if (IsShow)
            {
                if (null != gb)
                    this.gb.Visible = false;
                if (null != Panap)
                    this.Panap.Visible = false;
                IsShow = false;
            }
            else
            {
                if (null != gb)
                    this.gb.Visible = true;
                if (null != Panap)
                    this.Panap.Visible = true;
                IsShow = true;
            }
        }
    }
}
