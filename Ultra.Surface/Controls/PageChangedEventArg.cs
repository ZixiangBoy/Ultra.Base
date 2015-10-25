using System;
using System.Runtime.CompilerServices;

namespace Ultra.Surface.Controls
{
    public class PageChangedEventArg : EventArgs
    {
        public PageChangedEventArg()
        {
        }

        public PageChangedEventArg(int idx)
        {
            this.CurrentPageIndex = idx;
        }

        public int CurrentPageIndex { get; internal set; }
    }
}

