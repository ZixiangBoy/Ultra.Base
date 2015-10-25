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
    public partial class MainSurface : BaseSurface
    {
        public MainSurface()
        {
            InitializeComponent();
            this.bar1.OptionsBar.MultiLine = false;
        }
    }
}
