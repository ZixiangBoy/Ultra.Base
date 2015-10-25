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
    public partial class DialogViewEx : DialogView
    {
        public DialogViewEx()
        {
            InitializeComponent();
            this.Load += (s1, e1) =>
            {
                this.btnClose.Left = this.Width - this.btnClose.Width - 30;
                this.btnOK.Left = this.btnClose.Left - this.btnOK.Width - 10;
            };
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
