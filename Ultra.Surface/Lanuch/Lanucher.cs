using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.UserSkins;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Web.Core.Configuration;

namespace Ultra.Surface.Lanuch
{
    /// <summary>
    /// 模块启动器
    /// </summary>
    public sealed class Lanucher
    {
        private Lanucher() { }
        private static readonly string SkinKey = "Surface.SkinName";
        static Lanucher()
        {
            optcfg = new OptionConfig(EnOptionConfigType.App);
            _connstr = GetConnString();
            cahe = new Ultra.Web.Core.Cache.CacheBase();
            //OfficeSkins.Register();
            BonusSkins.Register();
            var skn = optcfg.Get<string>("SkinName");
            if (!string.IsNullOrEmpty(skn))
            {
                cahe.Put<string>(SkinKey, skn);
            }
            else
                cahe.Put<string>(SkinKey, string.Empty);

            DevExpress.Skins.SkinManager.EnableFormSkins();
        }

        public static void ReLoadSkinName()
        {
            var skn = optcfg.Get<string>("SkinName");
            if (!string.IsNullOrEmpty(skn))
            {
                cahe.Put<string>(SkinKey, skn);
            }
        }

        public static void Clean(string arg)
        {
            if (arg == "OfficeSkins.Register()")
            {
                cahe = null;
                cahe = new Ultra.Web.Core.Cache.CacheBase();
            }
        }

        private static Lanucher _ins = null;

        public static Lanucher Instance
        {
            get
            {
                return _ins = (_ins == null ? new Lanucher() : _ins);
            }
        }

        private static string _connstr = string.Empty;
        private static OptionConfig optcfg = null;
        private static Ultra.Web.Core.Cache.ICache cahe = null;
        public static string ConnectonString
        {
            get
            {
                return _connstr;
            }
        }

        public static string AppDir
        {
            get
            {
                return Path.GetDirectoryName(Application.ExecutablePath);
            }
        }

        /// <summary>
        /// 启动模块
        /// </summary>
        /// <param name="clsName">模块类名</param>
        /// <param name="modName">模块DLL文件名</param>
        /// <returns>模块对象</returns>
        public static BaseSurface Start(string clsName, string modName = "")
        {
            if (string.IsNullOrEmpty(clsName)) throw new Exception("模块类名为空..");
            var ph = string.Empty;
            var pth = Path.GetDirectoryName(Application.ExecutablePath);

            if (string.IsNullOrEmpty(modName))
            {
                ph = GetPathByClsName(clsName);
            }
            else
            {
                ph = Path.Combine(pth, modName);
                if (!File.Exists(ph))
                {
                    throw new ArgumentException("找不到 " + modName + " 指定的DLL文件!", "modName");
                }
            }
            var asm = Assembly.LoadFrom(ph);
            var obj = asm.CreateInstance(clsName);
            var vw = obj as BaseSurface;
            //vw.OptConfig = optcfg;
            //vw.ConnString = _connstr;
            //vw.Cacher = cahe;
            var isp = vw as ISurfacePermission;
            if (null != isp)
            {
                vw.Load += (s1, e1) =>
                {
                    ReqPermit.Invoke(null, new object[] { vw });
                };
            }
            InitView(vw);

            return vw;
        }

        /// <summary>
        /// 设定画面相关参数及对象
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static BaseSurface InitView(BaseSurface view)
        {
            if (null == view) return view;
            view.OptConfig = optcfg;
            view.ConnString = _connstr;
            view.Cacher = cahe;
            if (!string.IsNullOrEmpty(cahe.Get<string>(SkinKey)))
                view.defaultLookAndFeel1.LookAndFeel.SetSkinStyle(cahe.Get<string>(SkinKey));
            return view;
        }

        internal static string GetConnString()
        {
            string k = null;
            foreach (System.Configuration.ConnectionStringSettings ki in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                if (string.Compare(ki.Name, "dbconstr") == 0)
                    k = ki.ToString();
            }
            if (null == k)
                return Util.Decrypt("6D28164147BDB6D6353980051B008AA6F3D3FA0563FF51C6F79C0C8F3583676B12E619249605A1FA44AEB4F5B98B1BB17ED65C19365CA2678950923F2AAAF54FF9959295AE3C66057412FA162B410A7C3D486F52CF39CBDDC5136418C58B9B74");
            //return Util.Decrypt(k.ToString());
            return k;
        }

        /// <summary>
        /// 获取 类对应的模块文件名
        /// </summary>
        /// <param name="clsName">类限定名</param>
        /// <returns>类对应的模块文件名</returns>
        internal static string GetPathByClsName(string clsName)
        {
            //将类名按点分号分隔
            var ps = clsName.Split(".".ToCharArray());
            if (null == ps || ps.Length < 1) { throw new ArgumentException("无效的类名,请给定类全限定名", "clsName"); }
            var pl = new List<string>(ps.Length);
            for (int i = 0; i < ps.Length; i++)
                if (!string.IsNullOrEmpty(ps[i]))
                    pl.Add(ps[i]);
            var ph = BuildPath(pl);
            if (string.IsNullOrEmpty(ph))
                throw new ArgumentException("无法找到 " + clsName + " 对应的模块文件!", "clsName");
            return ph;
        }

        /// <summary>
        /// 根据类名点分获取DLL名称
        /// </summary>
        /// <param name="clsNamespt"></param>
        /// <returns></returns>
        internal static string BuildPath(List<string> clsNamespt)
        {
            var k = clsNamespt.Count;
            int j = 1;
            var pth = Path.GetDirectoryName(Application.ExecutablePath);
            var ph = string.Empty;
            for (int i = 0; i < k - j; i++)//, j++
            {
                ph += clsNamespt[i] + ".";
            }
            ph += "dll";
            if (File.Exists(Path.Combine(pth, ph)))
                return Path.Combine(pth, ph);

            return string.Empty;
        }

        ///// <summary>
        ///// 检查是否正常连接至数据库
        ///// </summary>
        ///// <returns></returns>
        //public static bool CanConnDb()
        //{
        //    try
        //    {
        //        using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection
        //    (Lanucher._connstr))
        //        {
        //            con.Open();
        //        }
        //        return true;
        //    }
        //    catch
        //    { return false; }
        //}

        internal static MethodInfo mreq = null;

        static MethodInfo ReqPermit
        {
            get
            {
                if (null == mreq)
                    GetMReq();
                return mreq;
            }
        }

        private static void GetMReq()
        {
            var asm = Assembly.LoadFile(Path.Combine(AppDir, "Ultra.Login.dll"));
            if (null == asm) return;
            var mi = asm.GetType("Ultra.Login.LoadPermit").GetMethod("RequestPermit",
                  BindingFlags.Public | BindingFlags.Static);
            if (null == mi) return;
            mreq = mi;
        }
    }
}
