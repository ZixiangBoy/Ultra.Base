using System;
using System.Runtime.InteropServices;


namespace Ultra.Surface.Form
{

    /// <summary>
    /// The wrapper class for GDI32.dll
    /// </summary>
    public static class GDI32Dll
    {
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateDIBSection(IntPtr hdc
            , [In] ref BITMAPINFOHEADER pbmi
            , uint iUsage
            , out IntPtr ppvBits
            , IntPtr hSection
            , uint dwOffset
            );

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
    }
}
