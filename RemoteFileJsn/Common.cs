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
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace RemoteFileJsn {
    public static class Common {

        /// <summary>
        /// 序列化对象为Json串
        /// </summary>
        /// <param name="obj">要被序列化的对象</param>
        /// <returns></returns>
        public static string SerializeJson(this object obj) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                new Newtonsoft.Json.JsonSerializerSettings() {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
        }

         //<summary>
         //反序列化对象
         //</summary>
         //<typeparam name="T">泛型类型</typeparam>
         //<param name="jsonstr">Json串</param>
         //<returns></returns>
        public static T DeSerialize<T>(string jsonstr) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstr);
        }

        //public static T DeSerialize<T>(string jsn)
        //{
        //    //反射泛型方法
        //    var utildll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Newtonsoft.Json.dll");
        //    if (!File.Exists(utildll)) { return default(T); }
        //    var bts = File.ReadAllBytes(utildll);
        //    var asm = System.Reflection.Assembly.Load(bts); if (null == asm) return default(T);
        //    var t = asm.GetType("Newtonsoft.Json.JsonConvert"); if (null == t) return default(T);
        //    var mi = t.GetMethods().First(j => j.Name == "DeserializeObject" && j.IsGenericMethod && j.GetGenericArguments().Length == 1)
        //        ;
        //    var mig = mi.MakeGenericMethod(typeof(T)); if (mig == null) return default(T);
        //    var ojd = mig.Invoke(null, new object[] { jsn });
        //    return (T)Convert.ChangeType(ojd, typeof(T));
        //}

        public static T Copy<T>(this object obj) {
            return DeSerialize<T>(obj.SerializeJson());
        }

        /// <summary>
        /// 给实体的默认属性设置上默认值
        /// </summary>
        /// <param name="et"></param>
        public static void SetDefEntity(dynamic et) {
            et.Guid = Guid.NewGuid();
            et.Remark = string.IsNullOrEmpty(et.Remark) ? string.Empty : et.Remark;
            et.Reserved1 = 0; et.Reserved2 = string.Empty; et.Reserved3 = false;
        }

        private static SaveFileDialog _fdlg = null;
        internal static SaveFileDialog fdlg {
            get {
                return _fdlg = _fdlg == null ? new SaveFileDialog() : _fdlg;
            }
        }

        /// <summary>
        /// 字符串转颜色
        /// </summary>
        /// <param name="clor"></param>
        /// <returns></returns>
        public static System.Drawing.Color ToColor(this string clor) {
            return GetColorFromString(clor);
        }

        /// <summary>
        /// 字符串转颜色
        /// </summary>
        /// <param name="colorString"></param>
        /// <returns></returns>
        public static Color GetColorFromString(string colorString) {
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
        public static List<string> GetMACs(out string mac) {
            string MAC = string.Empty;
            NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
            List<string> MACS = new List<string>();
            foreach (NetworkInterface ni in nis) {
                if (ni.NetworkInterfaceType != NetworkInterfaceType.Loopback
                    && ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                    && ni.OperationalStatus == OperationalStatus.Up) {
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
        public static string GetRemoteIP() {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(@"http://www.keyisoft.cn/hello.asp");
            var res = (HttpWebResponse)req.GetResponse();
            using (var sm = new StreamReader(res.GetResponseStream())) {
                return sm.ReadToEnd();
            }
        }

        /// <summary>
        /// 获取本机IPV4 IP
        /// </summary>
        /// <param name="LocalIP"></param>
        /// <returns></returns>
        public static string[] GetLocalIpv4(out string LocalIP) {
            LocalIP = string.Empty;
            //事先不知道ip的个数，数组长度未知，因此用StringCollection储存
            IPAddress[] localIPs;
            localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            StringCollection IpCollection = new StringCollection();
            foreach (IPAddress ip in localIPs) {
                //根据AddressFamily判断是否为ipv4,如果是InterNetWorkV6则为ipv6
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    LocalIP = ip.ToString();
                    IpCollection.Add(ip.ToString());
                }
            }
            string[] IpArray = new string[IpCollection.Count];
            IpCollection.CopyTo(IpArray, 0);
            return IpArray;
        }

        /// <summary>
        /// 判断指定端口号是否可用
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool ServerPortCanUse(this string port) {
            int prt = 0;
            if (string.IsNullOrEmpty(port) || !
            int.TryParse(port, out prt))
                return false;
            return CheckAvailableServerPort(prt);
        }

        /// <summary>
        /// 判断指定端口号是否可用
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool ServerPortCanUse(this int port) {
            return CheckAvailableServerPort(port);
        }

        private static bool CheckAvailableServerPort(int port) {
            bool isAvailable = true;

            // Evaluate current system tcp connections. This is the same information provided
            // by the netstat command line application, just in .Net strongly-typed object
            // form.  We will look through the list, and if our port we would like to use
            // in our TcpClient is occupied, we will set isAvailable to false.
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endpoint in tcpConnInfoArray) {
                if (endpoint.Port == port) {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        /// <summary>
        /// 判断字符是否包含中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsContainChinese(this string str) {
            var rgx = new System.Text.RegularExpressions.Regex("[\u4e00-\u9fa5]");
            return (rgx.IsMatch(str));
        }

        // 把阿拉伯数字的金额转换为中文大写数字
        public static string ToChinese(this decimal x) {
            string s = x.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            return Regex.Replace(d, ".", delegate(Match m) { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
        }

        // 把阿拉伯数字的金额转换为中文大写数字
        public static string ToChinese(this double x) {
            string s = x.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            return Regex.Replace(d, ".", delegate(Match m) { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
        }

        /// <summary>
        /// 正则匹配第一个扣号中的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="rgx"></param>
        /// <returns></returns>
        public static string RgxFirstMatch(this string str, Regex rgx) {
            var mch = rgx.Match(str);
            if (null == mch || mch.Groups == null || mch.Groups.Count < 2) return string.Empty;
            return mch.Groups[1].Value;
        }

        /// <summary>
        /// 正则匹配第一个扣号中的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="rgx"></param>
        /// <param name="ignorcase"></param>
        /// <returns></returns>
        public static string RgxFirstMatch(this string str, string rgx, bool ignorcase = true) {
            return RgxFirstMatch(str, new Regex(rgx, ignorcase ? RegexOptions.IgnoreCase : RegexOptions.None));
        }
    }
}
