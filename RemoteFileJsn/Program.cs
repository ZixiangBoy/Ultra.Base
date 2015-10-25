using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace RemoteFileJsn
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<Process> pss = null; DetectERP(out pss);
            Application.Run(new Form1());
        }

        public static bool DetectERP(out List<Process> pss)
        {
            try
            {
                pss = new List<Process>();
                var pcs = Process.GetProcesses();
                foreach (var j in pcs)
                {
                    if (string.Compare(j.ProcessName, "Ultra.ERP", true) == 0 ||
                        string.Compare(j.ProcessName, "ERP", true) == 0
                        )
                        pss.Add(j);
                }
                //var pcs = Process.GetProcessesByName("Ultra.ERP.exe");
                //var ps = Process.GetProcessesByName("客易ERP");
                //if (null != pcs && pcs.Length > 0 && null != ps && ps.Length > 0)
                //{
                //    pss.AddRange(pcs); pss.AddRange(ps);
                //    return true;
                //}
                return false;
            }
            catch (Exception ex)
            {
                pss = null;
                return false;
            }
        }
    }
}
