/********************************************************************	
	created:	2012-02-16
	author:		Szy
	contract	yanswer@msn.com
	company:	Ultra	
	purpose:	系统API调用
	project code: Powerful
	history:	
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// 系统调用
    /// </summary>
    public static class SystemInvoke
    {
        public enum ShowCommands : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }

        /// <summary>
        /// Shell 打开
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lpOperation"></param>
        /// <param name="lpFile"></param>
        /// <param name="lpParameters"></param>
        /// <param name="lpDirectory"></param>
        /// <param name="nShowCmd"></param>
        /// <returns></returns>
        [DllImport("shell32.dll ")]
        public static extern IntPtr ShellExecute(
                IntPtr hwnd,
                string lpOperation,
                string lpFile,
                string lpParameters,
                string lpDirectory,
                ShowCommands nShowCmd);

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void OpenFile(string fileName)
        {
            ShellExecute(IntPtr.Zero,"open",fileName,string.Empty,string.Empty,ShowCommands.SW_NORMAL);
        }

        /// <summary>
        /// 发送 Alt+F4
        /// </summary>
        public static void SendWindowCloseKey()
        {
            SendKeys.Send("%{F4}");
        }

        /// <summary>
        /// 发送 截屏键
        /// </summary>
        public static void SendPrtSc()
        {
            SendKeys.Send("{PrtSc}");
        }

        /// <summary>
        /// 构建一个可启动(随后即可直接调用Start())的进程
        /// </summary>
        /// <param name="procFileName">进程EXE文件路径</param>
        /// <param name="args">进程参数,可为null</param>
        /// <param name="exitHandler">进程退出时的通知事件回调,可为null</param>
        /// <returns>返回创建完成等待Start的进程</returns>
        public  static System.Diagnostics.Process StartProcess(string procFileName,string args=null,EventHandler exitHandler=null)
        {
            var pro = new System.Diagnostics.Process();
            pro.StartInfo.FileName = procFileName;
            if(!string.IsNullOrEmpty(args))
                pro.StartInfo.Arguments = args;
            pro.EnableRaisingEvents = true;
            if (null != exitHandler)
                pro.Exited += exitHandler;
            //pro.Start();
            return pro;
        }
    }
}
