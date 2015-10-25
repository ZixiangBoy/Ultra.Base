using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DoubleBullet.Surmnt.Surface.SuperForm;



namespace Ultra.Surface.Form
{
    [Serializable]
    public partial class FrameWorkBaseSuperView : Ultra.Surface.Form.BaseSurface
    {
        private Image m_BgImg;
        private string m_WndClsName = Guid.NewGuid().ToString("N");
        private IntPtr m_FakeWndHandle;
        private WndProcDelegate m_DefWndProcDelegate;
        private WndProcDelegate m_CtrlWndProcDelegate;
        private bool m_bIsRefreshing = false;
        private Dictionary<IntPtr, IntPtr> m_WndProcMap = new Dictionary<IntPtr, IntPtr>();

        /// <summary>
        /// Set the background image from file
        /// </summary>
        [Category("Appearance")]
        [Description("Set the background image from file")]
        public Image DlgBgImg
        {
            set { m_BgImg = value; }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (m_BgImg == null)
                return;

            base.AllowTransparency = true;
            base.Opacity = 0.01;// 0.05;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Width = m_BgImg.Width;
            base.Height = m_BgImg.Height;

            this.Move += new EventHandler(this.OnDlgMove);
            this.FormClosed += new FormClosedEventHandler(this.OnDlgClosed);

            m_DefWndProcDelegate = new WndProcDelegate(User32Dll.DefWindowProc);
            m_CtrlWndProcDelegate = new WndProcDelegate(this.CtrlWndProc);
            HookChildControl(this);

            CreateFakeWnd();
        }

        void OnDlgClosed(object sender, FormClosedEventArgs e)
        {
            DestroyFakeWnd();
            m_BgImg.Dispose();
            m_BgImg = null;
        }


        void HookChildControl(Control ctrl)
        {
            if (User32Dll.IsWindow(ctrl.Handle))
            {
                m_WndProcMap[ctrl.Handle]
                    = User32Dll.GetWindowLongPtr(ctrl.Handle, WindowsLong.GWL_WNDPROC);
                User32Dll.SetWindowLongPtr(ctrl.Handle
                    , WindowsLong.GWL_WNDPROC
                    , Marshal.GetFunctionPointerForDelegate(m_CtrlWndProcDelegate)
                    );
            }

            if (!ctrl.HasChildren)
                return;
            foreach (Control child in ctrl.Controls)
            {
                HookChildControl(child);
            }
        }


        IntPtr CtrlWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (!m_WndProcMap.ContainsKey(hWnd))
                return m_DefWndProcDelegate(hWnd, msg, wParam, lParam);

            IntPtr nRet = User32Dll.CallWindowProc(m_WndProcMap[hWnd], hWnd, msg, wParam, lParam);

            switch (msg)
            {
                case WindowsMessage.WM_PAINT:
                case WindowsMessage.WM_CTLCOLOREDIT:
                case WindowsMessage.WM_CTLCOLORBTN:
                case WindowsMessage.WM_CTLCOLORSTATIC:
                case WindowsMessage.WM_CTLCOLORMSGBOX:
                case WindowsMessage.WM_CTLCOLORDLG:
                case WindowsMessage.WM_CTLCOLORLISTBOX:
                case WindowsMessage.WM_CTLCOLORSCROLLBAR:
                case WindowsMessage.WM_CAPTURECHANGED:
                    RefreshFakeWnd();
                    break;

                default:
                    break;
            }

            return nRet;
        }


        void OnDlgMove(object sender, EventArgs e)
        {
            if (!User32Dll.IsWindow(m_FakeWndHandle))
                return;

            User32Dll.MoveWindow(m_FakeWndHandle, this.Left, this.Top, this.Width, this.Height, false);
            RefreshFakeWnd();
        }

        protected override void WndProc(ref Message msg)
        {
            // make the window movable by drag on the client area
            if (msg.Msg == ((int)WindowsMessage.WM_LBUTTONDOWN))
            {
                msg.Msg = WindowsMessage.WM_NCLBUTTONDOWN;
                msg.LParam = IntPtr.Zero;
                msg.WParam = new IntPtr((int)MousePositionCodes.HTCAPTION);
            }
            base.WndProc(ref msg);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            User32Dll.ShowWindow(m_FakeWndHandle
                , (int)(this.Visible ? WindowShowStyle.Show : WindowShowStyle.Hide)
                );
        }


        protected void CreateFakeWnd()
        {
            WNDCLASSEX wndClsEx = new WNDCLASSEX();
            wndClsEx.Init();
            wndClsEx.style = WndClassType.CS_VREDRAW | WndClassType.CS_HREDRAW;
            wndClsEx.lpfnWndProc = m_DefWndProcDelegate;
            wndClsEx.cbClsExtra = 0;
            wndClsEx.cbWndExtra = 0;
            wndClsEx.hInstance = Kernal32Dll.GetModuleHandle(null);
            wndClsEx.hIcon = IntPtr.Zero;
            wndClsEx.hIconSm = IntPtr.Zero;
            wndClsEx.hCursor = IntPtr.Zero;
            wndClsEx.hbrBackground = IntPtr.Zero;
            wndClsEx.lpszClassName = m_WndClsName;
            wndClsEx.lpszMenuName = null;

            bool success = User32Dll.RegisterClassEx(ref wndClsEx) != 0;
            Debug.Assert(success, "RegisterWndClass failed.");
            UInt32 dwExStyle = ExtendedWndStyle.WS_EX_LAYERED |
                ExtendedWndStyle.WS_EX_TRANSPARENT |
                ExtendedWndStyle.WS_EX_NOACTIVATE |
                ExtendedWndStyle.WS_EX_LEFT;
            UInt32 dwStyle = WndStyle.WS_VISIBLE | WndStyle.WS_OVERLAPPED;
            m_FakeWndHandle = User32Dll.CreateWindowEx(dwExStyle
                , m_WndClsName
                , null
                , dwStyle
                , this.Left
                , this.Top
                , m_BgImg.Width
                , m_BgImg.Height
                , this.Handle
                , IntPtr.Zero
                , Kernal32Dll.GetModuleHandle(null)
                , IntPtr.Zero
                );
            Debug.Assert(User32Dll.IsWindow(m_FakeWndHandle), "CreateWindowEx failed.");
        }

        protected void DestroyFakeWnd()
        {
            if (m_FakeWndHandle != IntPtr.Zero)
            {
                User32Dll.DestroyWindow(m_FakeWndHandle);
                m_FakeWndHandle = IntPtr.Zero;

                User32Dll.UnregisterClass(m_WndClsName, Kernal32Dll.GetModuleHandle(null));
            }
        }


        protected void RefreshFakeWnd()
        {
            if (m_bIsRefreshing)
                return;

            if (!User32Dll.IsWindow(m_FakeWndHandle))
                return;

            m_bIsRefreshing = true;
            POINT ptSrc = new POINT(0, 0);
            POINT ptWinPos = new POINT(this.Left, this.Top);
            SIZE szWin = new SIZE(m_BgImg.Width, m_BgImg.Height);
            byte biAlpha = 0xFF;
            BLENDFUNCTION stBlend = new BLENDFUNCTION(BlendOp.AC_SRC_OVER, 0, biAlpha, BlendOp.AC_SRC_ALPHA);

            IntPtr hDC = User32Dll.GetDC(m_FakeWndHandle);
            if (hDC == IntPtr.Zero)
            {
                m_bIsRefreshing = false;
                Debug.Assert(false, "GetDC failed.");
                return;
            }

            IntPtr hdcMemory = GDI32Dll.CreateCompatibleDC(hDC);

            int nBytesPerLine = ((m_BgImg.Width * 32 + 31) & (~31)) >> 3;
            BITMAPINFOHEADER stBmpInfoHeader = new BITMAPINFOHEADER();
            stBmpInfoHeader.Init();
            stBmpInfoHeader.biWidth = m_BgImg.Width;
            stBmpInfoHeader.biHeight = m_BgImg.Height;
            stBmpInfoHeader.biPlanes = 1;
            stBmpInfoHeader.biBitCount = 32;
            stBmpInfoHeader.biCompression = CompressionType.BI_RGB;
            stBmpInfoHeader.biClrUsed = 0;
            stBmpInfoHeader.biSizeImage = (uint)(nBytesPerLine * m_BgImg.Height);

            IntPtr pvBits = IntPtr.Zero;
            IntPtr hbmpMem = GDI32Dll.CreateDIBSection(hDC
                , ref stBmpInfoHeader
                , DIBColorTableIdentifier.DIB_RGB_COLORS
                , out pvBits
                , IntPtr.Zero
                , 0
                );
            Debug.Assert(hbmpMem != IntPtr.Zero, "CreateDIBSection failed.");

            if (hbmpMem != null)
            {
                IntPtr hbmpOld = GDI32Dll.SelectObject(hdcMemory, hbmpMem);

                Graphics graphic = Graphics.FromHdcInternal(hdcMemory);

                graphic.DrawImage(m_BgImg, 0, 0, m_BgImg.Width, m_BgImg.Height);

                foreach (Control ctrl in this.Controls)
                {
                    if (!ctrl.Visible)
                        continue;

                    using (Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height))
                    {
                        Rectangle rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
                        ctrl.DrawToBitmap(bmp, rect);

                        graphic.DrawImage(bmp, ctrl.Left, ctrl.Top, ctrl.Width, ctrl.Height);
                    }
                }

                GUITHREADINFO stGuiThreadInfo = new GUITHREADINFO();
                stGuiThreadInfo.Init();
                if (User32Dll.GetGUIThreadInfo(Kernal32Dll.GetCurrentThreadId(), ref stGuiThreadInfo))
                {
                    if (User32Dll.IsWindow(stGuiThreadInfo.hwndCaret))
                    {
                        int height = stGuiThreadInfo.rcCaret.Bottom - stGuiThreadInfo.rcCaret.Top;
                        POINT ptCaret = new POINT(stGuiThreadInfo.rcCaret.Left, stGuiThreadInfo.rcCaret.Top);

                        User32Dll.ClientToScreen(stGuiThreadInfo.hwndCaret, ref ptCaret);
                        User32Dll.ScreenToClient(this.Handle, ref ptCaret);

                        graphic.DrawLine(new Pen(new SolidBrush(Color.Black))
                            , ptCaret.X
                            , ptCaret.Y
                            , ptCaret.X
                            , ptCaret.Y + height
                            );
                    }
                }


                User32Dll.UpdateLayeredWindow(m_FakeWndHandle
                    , hDC
                    , ref ptWinPos
                    , ref szWin
                    , hdcMemory
                    , ref ptSrc
                    , 0
                    , ref stBlend
                    , UpdateLayerWindowParameter.ULW_ALPHA
                    );

                graphic.Dispose();
                GDI32Dll.SelectObject(hbmpMem, hbmpOld);
                GDI32Dll.DeleteObject(hbmpMem);
            }

            GDI32Dll.DeleteDC(hdcMemory);
            GDI32Dll.DeleteDC(hDC);

            m_bIsRefreshing = false;
        }

        
        
    }
}
