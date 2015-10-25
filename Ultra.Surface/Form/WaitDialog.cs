using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using System.Threading;

namespace Ultra.Surface.Form {
    public partial class WaitDialog : XtraForm {
        public class CloseEventArg : EventArgs {
            /// <summary>
            /// 表明是否取消后台工作,为true则表示取消,否则则继续后台工作
            /// </summary>
            public bool CancelWorking { get; set; }

            /// <summary>
            /// 附加参数对象
            /// </summary>
            public object ArgumentData { get; set; }
        }

        /// <summary>
        /// 由调用者定义的数据传递对象
        /// </summary>
        public object UserDefineData { get; set; }

        public WaitDialog() {
            InitializeComponent();

            lblMsg.Text = string.Empty;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hwnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        const uint SC_MOVE = 0xF010; //移动
        const uint SC_CLOSE = 0xF060;//关闭

        const uint MF_BYCOMMAND = 0x00; //按命令方式
        const uint MF_GRAYED = 0x01;    //灰掉
        const uint MF_DISABLED = 0x02;  //不可用

        ///// <summary>
        ///// 禁止关闭窗口
        ///// </summary>
        //public virtual void DisableClose()
        //{
        //    IntPtr hMenu = GetSystemMenu(this.Handle, false); //获取程序窗体的句柄

        //    if (hMenu != IntPtr.Zero)
        //    {
        //        //DeleteMenu(hMenu, SC_MOVE, MF_BYCOMMAND); //删除移动菜单，禁用移动功能
        //        EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED | MF_DISABLED); //禁用关闭功能
        //    }
        //}

        private bool _CanClose = true;

        /// <summary>
        /// 指示画面是否允许用户手动关闭
        /// </summary>
        [Category("Ultra")]
        [Description("指示画面是否允许用户手动关闭")]
        public bool CanClose {
            get { return _CanClose; }
            set { _CanClose = value; }
        }


        [Category("Ultra")]
        [Description("标签控件,用于显示等待提示信息")]
        public string MessageText {
            get { return lblMsg.Text; }
            set { lblMsg.Text = value; }
        }

        [Category("Ultra")]
        [Description("后台线程执行方法")]
        public event System.ComponentModel.DoWorkEventHandler OnBackGroundWorkRunning;

        [Category("Ultra")]
        [Description("后台线程完成方法")]
        public event RunWorkerCompletedEventHandler OnBackGroundWorkCompleted;

        [Category("Ultra")]
        [Description("在取消后台线程执行前")]
        public event EventHandler<CloseEventArg> BeforeBackGroundWorkCancel;

        /// <summary>
        /// ProgressMode为EnProgressMode.Progress时,CurrentValue>=MaxValue时触发事件
        /// </summary>
        [Category("Ultra")]
        [Description("ProgressMode为EnProgressMode.Progress时,CurrentValue>=MaxValue时触发事件")]
        public event EventHandler OnProgressCompleted;

        /// <summary>
        /// 画面模式
        /// </summary>
        private EnProgressMode _ProgressMode = EnProgressMode.Normal;

        public EnProgressMode ProgressMode {
            get { return _ProgressMode; }
            set {
                _ProgressMode = value;
                switch (value) {
                    case EnProgressMode.Normal:
                        pgb.Visible = false;
                        this.marqueeProgressBarControl1.Visible = true;
                        break;
                    case EnProgressMode.Progress:
                        this.marqueeProgressBarControl1.Visible = false;
                        this.pgb.Left = this.marqueeProgressBarControl1.Left;
                        this.pgb.Width = this.marqueeProgressBarControl1.Width;
                        this.pgb.Dock = this.marqueeProgressBarControl1.Dock;
                        this.pgb.Anchor = this.marqueeProgressBarControl1.Anchor;
                        this.pgb.Top = this.marqueeProgressBarControl1.Top;
                        this.pgb.Visible = true;
                        this.pgb.Properties.Maximum = this.MaxValue;
                        this.pgb.Properties.Minimum = 0;
                        this.pgb.EditValue = this.CurrentValue;
                        break;
                    default:
                        break;
                }
            }
        }

        private string _ProgressModeTextFormat = "当前进度:{0}/{1}";

        /// <summary>
        /// 当启用ProgressMode为EnProgressMode.Progress时有效
        /// 显示文本的格式化串
        /// 默认为:当前进度:{0}/{1}
        /// </summary>
        public virtual string ProgressModeTextFormat {
            get { return _ProgressModeTextFormat; }
            set { _ProgressModeTextFormat = value; }
        }

        /// <summary>
        /// 当启用ProgressMode为EnProgressMode.Progress时有效
        /// 最大进度值
        /// </summary>
        public virtual int MaxValue {
            get { return _MaxValue; }
            set {
                _MaxValue = value < 0 ? 0 : value;

                //System.Threading.Tasks.Task.Factory.StartNew(ag =>
                ThreadPool.QueueUserWorkItem(new WaitCallback(ag => {
                    try {
                        if (this.IsHandleCreated && !this.IsDisposed && this.pgb.Visible) {
                            this.Invoke(new Action(() => {
                                this.pgb.Properties.Maximum = (int)ag;
                                this.MessageText = string.Format(ProgressModeTextFormat, this.CurrentValue,
                                    (int)ag);
                            }));
                        }
                    } catch (ObjectDisposedException) { }
                }),
                    _MaxValue);
            }
        }

        private int _curValue = 0;
        private int _MaxValue = 0;

        /// <summary>
        /// 当启用ProgressMode为EnProgressMode.Progress时有效
        /// 当前进度值
        /// </summary>
        public virtual int CurrentValue {
            get { return _curValue; }
            set {
                _curValue = value < 0 ? 0 : value;
                if (_curValue >= MaxValue && null != this.OnProgressCompleted)
                    this.OnProgressCompleted(this, new EventArgs());
                // System.Threading.Tasks.Task.Factory.StartNew(ag =>
                ThreadPool.QueueUserWorkItem(new WaitCallback(ag => {
                    try {
                        if (this.IsHandleCreated && !this.IsDisposed && this.pgb.Visible) {
                            this.Invoke(new Action(() => {
                                this.pgb.EditValue = (int)ag;
                                this.MessageText = string.Format(ProgressModeTextFormat, (int)ag,
                                    this.MaxValue);
                            }));
                        }
                    } catch (ObjectDisposedException) { }
                }),
                    _curValue);
            }
        }

        public bool CancellationPending {
            get {
                return this.bgkwkr.CancellationPending;
            }
        }

        public bool IsBusy {
            get {
                return this.bgkwkr.IsBusy;
            }
        }


        /// <summary>
        /// 是否提前终止后台执行
        /// </summary>
        public bool IsCanceled = false;

        private void bgkwkr_DoWork(object sender, DoWorkEventArgs e) {
            IsCanceled = false;
            if (null != this.OnBackGroundWorkRunning)
                this.OnBackGroundWorkRunning(this, e);
        }

        /// <summary>
        /// 开始异步执行
        /// </summary>
        /// <param name="obj"></param>
        public DialogResult RunAsyncWork(object obj) {
            IsCanceled = false;

            this.bgkwkr.RunWorkerAsync(obj);
            DialogResult dr = this.ShowDialog();
            return dr;
        }

        public DialogResult RunAsyncWork() { return RunAsyncWork(null); }

        /// <summary>
        /// 取消后台工作,返回true表示同意取消后台工作
        /// </summary>
        /// <returns>返回true表示同意取消后台工作</returns>
        public bool CancelAsync() {
            var evtarg = new CloseEventArg();
            IsCanceled = true;
            if (null != this.BeforeBackGroundWorkCancel) {
                this.BeforeBackGroundWorkCancel(this, evtarg);
                if (!evtarg.CancelWorking)
                    return false;//参数返回不取消后台工作
            }
            IsCanceled = true;
            bgkwkr.WorkerSupportsCancellation = true;


            bgkwkr.CancelAsync();
            return true;
        }

        private void bgkwkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!this.IsHandleCreated || this.IsDisposed)
                return;

            if (null != this.OnBackGroundWorkCompleted) {
                this.OnBackGroundWorkCompleted(sender, e);
            }

            this.Invoke(new MethodInvoker(() => {
                Close();
            }));
        }

        private void WaitDialog_FormClosing(object sender, FormClosingEventArgs e) {
            if (bgkwkr.IsBusy) {
                if (!CanClose) { e.Cancel = true; return; }
                DialogResult = DialogResult.Cancel;
                var bCancel = this.CancelAsync();
                if (!bCancel) { e.Cancel = true; return; }
            } else
                DialogResult = DialogResult.OK;
        }
    }

    public enum EnProgressMode : int {
        Normal = 1,

        Progress = 2,
    }
}