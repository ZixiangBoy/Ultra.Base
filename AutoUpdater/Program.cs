using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;

namespace AutoUpdater
{
    static class Program {
        public static string apppath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Error.log"); 
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;

            bool bHasError = false;
            IAutoUpdater autoUpdater = new AutoUpdater();
            try {
                autoUpdater.CheckUpdate();
            } catch (Exception e) {
                var errmsg = string.Format("{0}{1}{2}",DateTime.Now+Environment.NewLine,e.Message+Environment.NewLine,e.StackTrace+Environment.NewLine);
                File.AppendAllText(apppath, errmsg);
                bHasError = true;
            } finally {
                if (bHasError == true) {
                    try {
                        autoUpdater.RollBack();
                    } catch (Exception) {
                        //Log the message to your file or database
                    }
                }
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var errmsg = string.Format("{0}{1}{2}", DateTime.Now + Environment.NewLine, e.Exception.Message + Environment.NewLine, e.Exception.StackTrace + Environment.NewLine);
            File.AppendAllText(apppath, errmsg);
        }
    }
}
