using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using System.Web.Http;
using System.Threading;
using System.Windows.Forms;

namespace FileServer
{
    static class Program {
      public static Ultra.Log.ApplicationLog AppLog;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppLog = new Ultra.Log.ApplicationLog();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            var config = new HttpSelfHostConfiguration("http://localhost:30000");
            config.MessageHandlers.Add(new FileHandler());
            config.MaxReceivedMessageSize = 2147483647;//允许接收的文件大小
            //TokenInspector tokenInspector = new TokenInspector() {
            //    InnerHandler =
            //        new System.Web.Http.Dispatcher.HttpControllerDispatcher(config)
            //};

            config.Routes.MapHttpRoute(
               "Default", "api/{controller}/{id}",
               new { id = RouteParameter.Optional }
               //, constraints: null
               //, handler: null
               );

            try
            {
                using (HttpSelfHostServer server = new HttpSelfHostServer(config))
                {
                    server.OpenAsync().Wait();
                    AppLog.DebugException(new Exception("PortNumber:30000"));
                    var t = new Thread(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(30 * 60 * 1000);
                            GC.Collect();
                        }
                    });
                    t.IsBackground = true;
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    t.Join();
                }
            }
            catch (Exception ex)
            {
                AppLog.DebugException(ex);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            AppLog.DebugException(e.Exception);
        }
    }
}
