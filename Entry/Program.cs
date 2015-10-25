using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Lanuch;
using Ultra.Web.Core.Common;
using Ultra.Web.Core.Configuration;
using Ultra.Web.Core.Interface;

namespace Entry
{
    static class Program
    {
        static Ultra.Log.ApplicationLog AppLog;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            AppLog = new Ultra.Log.ApplicationLog();
        __start:


            string con = string.Empty;
            BaseSurface vw;
            vw = Lanucher.Start("Ultra.Login.LoginView");//.ShowDialog();
            con = Lanucher.ConnectonString;

            if (!CanConnDb(con))
            {
                MsgBox.ShowMessage("无法连接至服务器", "无法连接至服务器!");
            }
            using (var db = new Database())
            {
                var dte = db.ExecuteScalar<DateTime>("select getdate()");
                TimeSync.Default.StartSync(dte);
            }
            var dt = vw.ShowDialog();
            if (dt == DialogResult.OK)//登录成功
            {
                if (null == args || args.Length < 1)
                    vw = Lanucher.Start("Ultra.Login.MainView");
                else
                    vw = Lanucher.Start(args[0]);
            }
            else if (dt == DialogResult.Cancel)//退出
            {
                return;
            }
            dt = vw.ShowDialog();
            if (dt == DialogResult.No)
            {
                Lanucher.Clean("OfficeSkins.Register()");
                goto __start;
            }

        }

        /// <summary>1
        /// 检查是否正常连接至数据库
        /// </summary>
        /// <returns></returns>
        static bool CanConnDb(string _connstr)
        {
            try
            {
                using (SqlConnection con = new SqlConnection
            (_connstr))
                {
                    con.Open();
                }
                return true;
            }
            catch { return false; }
        }


        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), "系统异常");
            AppLog.DebugException(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString(), "系统异常");
            AppLog.DebugException(new Exception(e.ExceptionObject.ToString()));
        }
    }
}
