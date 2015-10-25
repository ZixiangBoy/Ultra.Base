using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ultra.Surface.Controls {
    public partial class PagerControl : UserControl {
        private int _PageIndex = 1;
        private int _PageSize = 50;
        private int _TotalDataCount;


        public event EventHandler<PageChangedEventArg> OnPageIndexChanged;

        public PagerControl() {
            InitializeComponent();
        }

        private void comPageSize_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.comPageSize.Text == "最大值") {
                this._PageSize = 0x7fffffff;
            } else {
                this._PageSize = int.Parse(this.comPageSize.Text);
            }
            if (this.OnPageIndexChanged != null) {
                PageChangedEventArg arg = new PageChangedEventArg {
                    CurrentPageIndex = 1
                };
                this.OnPageIndexChanged(this, arg);
            }
            this.lblResult.Text = "当前页数：" + this.PageIndex.ToString() + "/" + this.MaxPageCount() + "页  总数：" + this.TotalDataCount.ToString() + "条";
        }

        private void lblFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.PageIndex = 1;
            if (this.OnPageIndexChanged != null) {
                PageChangedEventArg arg = new PageChangedEventArg {
                    CurrentPageIndex = 1
                };
                this.OnPageIndexChanged(this, arg);
            }
            this.lblResult.Text = "当前页数：" + this.PageIndex.ToString() + "/" + this.MaxPageCount() + "页  总数：" + this.TotalDataCount.ToString() + "条";
        }

        private void lblLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.PageIndex = this.MaxPageCount();
            if (this.OnPageIndexChanged != null) {
                PageChangedEventArg arg = new PageChangedEventArg {
                    CurrentPageIndex = this.PageIndex
                };
                this.OnPageIndexChanged(this, arg);
            }
            this.lblResult.Text = "当前页数：" + this.PageIndex.ToString() + "/" + this.MaxPageCount() + "页  总数：" + this.TotalDataCount.ToString() + "条";
        }

        private void lblNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            int num = this.MaxPageCount();
            this.PageIndex = ((this.PageIndex + 1) > num) ? num : (this.PageIndex + 1);
            if (this.OnPageIndexChanged != null) {
                PageChangedEventArg arg = new PageChangedEventArg {
                    CurrentPageIndex = this.PageIndex
                };
                this.OnPageIndexChanged(this, arg);
            }
            this.lblResult.Text = "当前页数：" + this.PageIndex.ToString() + "/" + this.MaxPageCount() + "页  总数：" + this.TotalDataCount.ToString() + "条";
        }

        private void lblPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.PageIndex = ((this.PageIndex - 1) < 1) ? 1 : (this.PageIndex - 1);
            if (this.OnPageIndexChanged != null) {
                PageChangedEventArg arg = new PageChangedEventArg {
                    CurrentPageIndex = this.PageIndex
                };
                this.OnPageIndexChanged(this, arg);
            }
            this.lblResult.Text = "当前页数：" + this.PageIndex.ToString() + "/" + this.MaxPageCount() + "页  总数：" + this.TotalDataCount.ToString() + "条";
        }

        protected int MaxPageCount() {
            int num = this._TotalDataCount / this.PageSize;
            int num2 = this._TotalDataCount % this.PageSize;
            num = (num2 > 0) ? (num + 1) : num;
            txtTo.Text = string.Empty;
            this.lblFirst.Enabled = this.lblPrev.Enabled = this.lblNext.Enabled = this.lblLast.Enabled = this.txtTo.Enabled = num > 0;
            this.lblResult.Text = "当前页数：" + this.PageIndex.ToString() + "/" + num + "页  总数：" + this.TotalDataCount.ToString() + "条";
            this.label2.Visible = this.lblResult.Visible = num > 0;
            comPageSize.Enabled = num > 0;
            return num;
        }

        protected override void OnCreateControl() {
            base.OnCreateControl();
            this.MaxPageCount();
        }

        private void txtTo_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                this.PageIndex = int.Parse(this.txtTo.Text);
                this.txtTo.Text = this.PageIndex.ToString();
                if (this.OnPageIndexChanged != null) {
                    PageChangedEventArg arg = new PageChangedEventArg {
                        CurrentPageIndex = this.PageIndex
                    };
                    this.OnPageIndexChanged(this, arg);
                }
                this.lblResult.Text = "当前页数：" + this.PageIndex.ToString() + "/" + this.MaxPageCount().ToString() + "页  总数：" + this.TotalDataCount.ToString() + "条";
            }
        }

        public int PageIndex {
            get {
                return this._PageIndex;
            }
            internal set {
                this._PageIndex = value;
            }
        }

        [Description("每页大小"), Category("Apex"), Browsable(true)]
        public int PageSize {
            get {
                return this._PageSize;
            }
            set {
                this._PageSize = (value < 1) ? 1 : value;
            }
        }

        [Category("Apex"), Description("总记录数"), Browsable(true)]
        public int TotalDataCount {
            get {
                return this._TotalDataCount;
            }
            set {
                this._TotalDataCount = value;
                this.MaxPageCount();
            }
        }

    }
}
