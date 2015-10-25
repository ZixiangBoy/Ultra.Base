using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Ultra.Surface.Form
{
    /// <summary>
    /// Define the window messages
    /// </summary>
    public static class WindowsMessage
    {
        public const Int32 WM_LBUTTONDOWN = 0x0201;
        public const Int32 WM_NCLBUTTONDOWN = 0x00A1;
        public const Int32 WM_SYSCOMMAND = 0x112;
        public const Int32 WM_PAINT = 0x000F;
        public const Int32 WM_MOVE = 0x0003;
        public const Int32 WM_CTLCOLORMSGBOX = 0x0132;
        public const Int32 WM_CTLCOLOREDIT = 0x0133;
        public const Int32 WM_CTLCOLORLISTBOX = 0x0134;
        public const Int32 WM_CTLCOLORBTN = 0x0135;
        public const Int32 WM_CTLCOLORDLG = 0x0136;
        public const Int32 WM_CTLCOLORSCROLLBAR = 0x0137;
        public const Int32 WM_CTLCOLORSTATIC = 0x0138;
        public const Int32 WM_CAPTURECHANGED = 0x0215;
    }

    /// <summary>
    /// Define the window class types
    /// </summary>
    public static class WndClassType
    {
        public const Int32 CS_VREDRAW = 0x0001;
        public const Int32 CS_HREDRAW = 0x0002;
        public const Int32 CS_DBLCLKS = 0x0008;
        public const Int32 CS_OWNDC = 0x0020;
        public const Int32 CS_CLASSDC = 0x0040;
        public const Int32 CS_PARENTDC = 0x0080;
        public const Int32 CS_NOCLOSE = 0x0200;
        public const Int32 CS_SAVEBITS = 0x0800;
        public const Int32 CS_BYTEALIGNCLIENT = 0x1000;
        public const Int32 CS_BYTEALIGNWINDOW = 0x2000;
        public const Int32 CS_GLOBALCLASS = 0x4000;
        public const Int32 CS_IME = 0x00010000;
        public const Int32 CS_DROPSHADOW = 0x00020000;
    }

    /// <summary>
    /// Window style
    /// </summary>
    public static class WndStyle
    {
        public const UInt32 WS_OVERLAPPED = 0x00000000;
        public const UInt32 WS_POPUP = 0x80000000;
        public const UInt32 WS_CHILD = 0x40000000;
        public const UInt32 WS_MINIMIZE = 0x20000000;
        public const UInt32 WS_VISIBLE = 0x10000000;
        public const UInt32 WS_DISABLED = 0x08000000;
        public const UInt32 WS_CLIPSIBLINGS = 0x04000000;
        public const UInt32 WS_CLIPCHILDREN = 0x02000000;
        public const UInt32 WS_MAXIMIZE = 0x01000000;
        public const UInt32 WS_CAPTION = 0x00C00000;
        public const UInt32 WS_BORDER = 0x00800000;
        public const UInt32 WS_DLGFRAME = 0x00400000;
        public const UInt32 WS_VSCROLL = 0x00200000;
        public const UInt32 WS_HSCROLL = 0x00100000;
        public const UInt32 WS_SYSMENU = 0x00080000;
        public const UInt32 WS_THICKFRAME = 0x00040000;
        public const UInt32 WS_GROUP = 0x00020000;
        public const UInt32 WS_TABSTOP = 0x00010000;
        public const UInt32 WS_MINIMIZEBOX = 0x00020000;
        public const UInt32 WS_MAXIMIZEBOX = 0x00010000;
        public const UInt32 WS_TILED = WS_OVERLAPPED;
        public const UInt32 WS_ICONIC = WS_MINIMIZE;
        public const UInt32 WS_SIZEBOX = WS_THICKFRAME;
        public const UInt32 WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;
        public const UInt32 WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
        public const UInt32 WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU);
        public const UInt32 WS_CHILDWINDOW = (WS_CHILD);

    }

    /// <summary>
    /// Extended Window Styles
    /// </summary>
    public static class ExtendedWndStyle
    {
        public const UInt32 WS_EX_DLGMODALFRAME = 0x00000001;
        public const UInt32 WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const UInt32 WS_EX_TOPMOST = 0x00000008;
        public const UInt32 WS_EX_ACCEPTFILES = 0x00000010;
        public const UInt32 WS_EX_TRANSPARENT = 0x00000020;
        public const UInt32 WS_EX_MDICHILD = 0x00000040;
        public const UInt32 WS_EX_TOOLWINDOW = 0x00000080;
        public const UInt32 WS_EX_WINDOWEDGE = 0x00000100;
        public const UInt32 WS_EX_CLIENTEDGE = 0x00000200;
        public const UInt32 WS_EX_CONTEXTHELP = 0x00000400;
        public const UInt32 WS_EX_RIGHT = 0x00001000;
        public const UInt32 WS_EX_LEFT = 0x00000000;
        public const UInt32 WS_EX_RTLREADING = 0x00002000;
        public const UInt32 WS_EX_LTRREADING = 0x00000000;
        public const UInt32 WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const UInt32 WS_EX_RIGHTSCROLLBAR = 0x00000000;
        public const UInt32 WS_EX_CONTROLPARENT = 0x00010000;
        public const UInt32 WS_EX_STATICEDGE = 0x00020000;
        public const UInt32 WS_EX_APPWINDOW = 0x00040000;
        public const UInt32 WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        public const UInt32 WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        public const UInt32 WS_EX_LAYERED = 0x00080000;
        public const UInt32 WS_EX_NOINHERITLAYOUT = 0x00100000;
        public const UInt32 WS_EX_LAYOUTRTL = 0x00400000;
        public const UInt32 WS_EX_COMPOSITED = 0x02000000;
        public const UInt32 WS_EX_NOACTIVATE = 0x08000000;
    }

    /// <summary>
    /// WNDPROC
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="msg"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// WNDCLASSEX
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WNDCLASSEX
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint style;
        public WndProcDelegate lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszMenuName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszClassName;
        public IntPtr hIconSm;

        public void Init()
        {
            cbSize = (uint)Marshal.SizeOf(this);
        }
    }

    public enum MousePositionCodes : int
    {
        HTERROR = -2,
        HTTRANSPARENT = -1,
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTGROWBOX = 4,
        HTSIZE = HTGROWBOX,
        HTMENU = 5,
        HTHSCROLL = 6,
        HTVSCROLL = 7,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HTOBJECT = 19,
        HTCLOSE = 20,
        HTHELP = 21,
    }

    public static class BlendOp
    {
        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;
    }


    /// <summary>
    /// BLENDFUNCTION
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        byte BlendOp;
        byte BlendFlags;
        byte SourceConstantAlpha;
        byte AlphaFormat;

        public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
        {
            BlendOp = op;
            BlendFlags = flags;
            SourceConstantAlpha = alpha;
            AlphaFormat = format;
        }
    }

    /// <summary>
    /// POINT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator Point(POINT p)
        {
            return new Point(p.X, p.Y);
        }

        public static implicit operator POINT(Point p)
        {
            return new POINT(p.X, p.Y);
        }
    }

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int left_, int top_, int right_, int bottom_)
        {
            Left = left_;
            Top = top_;
            Right = right_;
            Bottom = bottom_;
        }

        public int Height { get { return Bottom - Top; } }
        public int Width { get { return Right - Left; } }
        public Size Size { get { return new Size(Width, Height); } }

        public Point Location { get { return new Point(Left, Top); } }

        public Rectangle ToRectangle()
        { return Rectangle.FromLTRB(Left, Top, Right, Bottom); }

        public static RECT FromRectangle(Rectangle rectangle)
        {
            return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
        }

        public override int GetHashCode()
        {
            return Left ^ ((Top << 13) | (Top >> 0x13))
              ^ ((Width << 0x1a) | (Width >> 6))
              ^ ((Height << 7) | (Height >> 0x19));
        }

        #region Operator overloads

        public static implicit operator Rectangle(RECT rect)
        {
            return rect.ToRectangle();
        }

        public static implicit operator RECT(Rectangle rect)
        {
            return FromRectangle(rect);
        }

        #endregion
    }


    /// <summary>
    /// SIZE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int cx;
        public int cy;

        public SIZE(int cx, int cy)
        {
            this.cx = cx;
            this.cy = cy;
        }
    }

    public static class CompressionType
    {
        public const byte BI_RGB = 0;
        public const byte BI_RLE8 = 1;
        public const byte BI_RLE4 = 2;
        public const byte BI_BITFIELDS = 3;
        public const byte BI_JPEG = 4;
        public const byte BI_PNG = 5;
    }

    public static class DIBColorTableIdentifier
    {
        public const byte DIB_RGB_COLORS = 0;
        public const byte DIB_PAL_COLORS = 1;
    }

    public static class UpdateLayerWindowParameter
    {
        public const int ULW_COLORKEY = 0x00000001;
        public const int ULW_ALPHA = 0x00000002;
        public const int ULW_OPAQUE = 0x00000004;
        public const int ULW_EX_NORESIZE = 0x00000008;
    }


    public static class WindowsLong
    {
        public const int GWL_WNDPROC = -4;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_USERDATA = -21;
        public const int GWL_ID = -12;
    }

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct GUITHREADINFO
    {
        public uint cbSize;
        public uint flags;
        public IntPtr hwndActive;
        public IntPtr hwndFocus;
        public IntPtr hwndCapture;
        public IntPtr hwndMenuOwner;
        public IntPtr hwndMoveSize;
        public IntPtr hwndCaret;
        public RECT rcCaret;

        public void Init()
        {
            cbSize = (uint)Marshal.SizeOf(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;

        public void Init()
        {
            biSize = (uint)Marshal.SizeOf(this);
        }
    }


    /// <summary>Enumeration of the different ways of showing a window using
    /// ShowWindow</summary>
    public enum WindowShowStyle : uint
    {
        /// <summary>Hides the window and activates another window.</summary>
        /// <remarks>See SW_HIDE</remarks>
        Hide = 0,
        /// <summary>Activates and displays a window. If the window is minimized
        /// or maximized, the system restores it to its original size and
        /// position. An application should specify this flag when displaying
        /// the window for the first time.</summary>
        /// <remarks>See SW_SHOWNORMAL</remarks>
        ShowNormal = 1,
        /// <summary>Activates the window and displays it as a minimized window.</summary>
        /// <remarks>See SW_SHOWMINIMIZED</remarks>
        ShowMinimized = 2,
        /// <summary>Activates the window and displays it as a maximized window.</summary>
        /// <remarks>See SW_SHOWMAXIMIZED</remarks>
        ShowMaximized = 3,
        /// <summary>Maximizes the specified window.</summary>
        /// <remarks>See SW_MAXIMIZE</remarks>
        Maximize = 3,
        /// <summary>Displays a window in its most recent size and position.
        /// This value is similar to "ShowNormal", except the window is not
        /// actived.</summary>
        /// <remarks>See SW_SHOWNOACTIVATE</remarks>
        ShowNormalNoActivate = 4,
        /// <summary>Activates the window and displays it in its current size
        /// and position.</summary>
        /// <remarks>See SW_SHOW</remarks>
        Show = 5,
        /// <summary>Minimizes the specified window and activates the next
        /// top-level window in the Z order.</summary>
        /// <remarks>See SW_MINIMIZE</remarks>
        Minimize = 6,
        /// <summary>Displays the window as a minimized window. This value is
        /// similar to "ShowMinimized", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWMINNOACTIVE</remarks>
        ShowMinNoActivate = 7,
        /// <summary>Displays the window in its current size and position. This
        /// value is similar to "Show", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWNA</remarks>
        ShowNoActivate = 8,
        /// <summary>Activates and displays the window. If the window is
        /// minimized or maximized, the system restores it to its original size
        /// and position. An application should specify this flag when restoring
        /// a minimized window.</summary>
        /// <remarks>See SW_RESTORE</remarks>
        Restore = 9,
        /// <summary>Sets the show state based on the SW_ value specified in the
        /// STARTUPINFO structure passed to the CreateProcess function by the
        /// program that started the application.</summary>
        /// <remarks>See SW_SHOWDEFAULT</remarks>
        ShowDefault = 10,
        /// <summary>Windows 2000/XP: Minimizes a window, even if the thread
        /// that owns the window is hung. This flag should only be used when
        /// minimizing windows from a different thread.</summary>
        /// <remarks>See SW_FORCEMINIMIZE</remarks>
        ForceMinimized = 11
    }
}
