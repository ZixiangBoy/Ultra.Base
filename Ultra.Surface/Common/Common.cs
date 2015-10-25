using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Interfaces;
using Ultra.Web.Core.Common;

namespace Ultra.Surface.Common
{

    public static class Common
    {
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="filepath"></param>
        public static void ConfirmExportOK(string filepath, bool showtip = true)
        {
            if (showtip)
            {
                if (MsgBox.ShowYesNoMessage("导出成功", "导出成功,是否立即打开?") == DialogResult.Yes)
                {
                    SystemInvoke.OpenFile(filepath);
                }
            }
            else
                SystemInvoke.OpenFile(filepath);
        }

        private static SaveFileDialog _fdlg = null;
        internal static SaveFileDialog fdlg
        {
            get
            {
                return _fdlg = _fdlg == null ? new SaveFileDialog() : _fdlg;
            }
        }

        /// <summary>
        /// Grid导出功能(2007)
        /// </summary>
        /// <param name="gc"></param>
        public static void GridExportXlsx(this DevExpress.XtraGrid.GridControl gc)
        {
            fdlg.Filter = "*.xlsx|*.xlsx";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                gc.ExportToXlsx(fdlg.FileName);
                ConfirmExportOK(fdlg.FileName, true);
            }
        }

        /// <summary>
        /// Grid导出功能(2003)
        /// </summary>
        /// <param name="gc"></param>
        public static void GridExportXls(this DevExpress.XtraGrid.GridControl gc) {
            fdlg.Filter = "*.xls|*.xls";
            if (fdlg.ShowDialog() == DialogResult.OK) {
                gc.ExportToXls(fdlg.FileName);
                ConfirmExportOK(fdlg.FileName, true);
            }
        }

        /// <summary>
        /// 字符串转颜色
        /// </summary>
        /// <param name="clor"></param>
        /// <returns></returns>
        public static System.Drawing.Color ToColor(this string clor)
        {
            return GetColorFromString(clor);
        }

        /// <summary>
        /// 字符串转颜色
        /// </summary>
        /// <param name="colorString"></param>
        /// <returns></returns>
        public static Color GetColorFromString(string colorString)
        {
            Color color = Color.Empty;
            ColorConverter converter = new ColorConverter();
            //try
            //{
            color = (Color)converter.ConvertFromString(colorString);
            //}
            //catch
            //{ }
            return color;
        }

        /// <summary>
        /// 获取本机网卡地址列表
        /// </summary>
        /// <param name="mac">输出 网卡地址</param>
        /// <returns></returns>
        public static List<string> GetMACs(out string mac)
        {
            string MAC = string.Empty;
            NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
            List<string> MACS = new List<string>();
            foreach (NetworkInterface ni in nis)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    PhysicalAddress pa = ni.GetPhysicalAddress();

                    MAC = pa.ToString();
                    MACS.Add(MAC);
                    //break;
                }
            }
            mac = MAC;
            if (MACS.Count > 0)
                return MACS;//MACS.Aggregate((s1, s2) => s1 + "," + s2).ToString();
            else
                return null;
        }

        /// <summary>
        /// 获取外网IP
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteIP()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(@"http://www.doublebullet.cn/hello.asp");
            var res = (HttpWebResponse)req.GetResponse();
            using (var sm = new StreamReader(res.GetResponseStream()))
            {
                return sm.ReadToEnd();
            }
        }

        /// <summary>
        /// 获取本机IPV4 IP
        /// </summary>
        /// <param name="LocalIP"></param>
        /// <returns></returns>
        public static string[] GetLocalIpv4(out string LocalIP)
        {
            LocalIP = string.Empty;
            //事先不知道ip的个数，数组长度未知，因此用StringCollection储存
            IPAddress[] localIPs;
            localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            StringCollection IpCollection = new StringCollection();
            foreach (IPAddress ip in localIPs)
            {
                //根据AddressFamily判断是否为ipv4,如果是InterNetWorkV6则为ipv6
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIP = ip.ToString();
                    IpCollection.Add(ip.ToString());
                }
            }
            string[] IpArray = new string[IpCollection.Count];
            IpCollection.CopyTo(IpArray, 0);
            return IpArray;
        }
    }
}
