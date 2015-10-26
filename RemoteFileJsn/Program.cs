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
