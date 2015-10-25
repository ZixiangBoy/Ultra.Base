/********************************************************************	
   created:	2012-09-20
   author:		wakaka
   contract	wakaka_wka@live.com
   company:	Ultra.Company	
   purpose:	自定义配置信息操作类
   project code: Ultra
   history:	
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.Web.Core.Interface;
using Ultra.Web.Core.Common;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

namespace Ultra.Web.Core.Configuration
{
    /// <summary>
    /// 用户自定义的相关配置
    /// </summary>
    public partial class OptionConfig : IOptionConfig
    {
        public OptionConfig(EnOptionConfigType _en = EnOptionConfigType.Web)
        {
            _OptionConfigType = _en;
        }

        public OptionConfig(string cfgFile)
        {
            _OptionConfigType = EnOptionConfigType.Optional;
            _optConfigFile = cfgFile;
        }

        protected string _optConfigFile { get; set; }

        /// <summary>
        /// 全局的可选应用程序配置信息保存文件名
        /// </summary>
        public static string OptionConfigFileName { get { return "Ultra.Web.Core.Configuration.Global.xml"; } }

        /// <summary>
        /// 全局的可选应用程序配置信息保存文件在站点上的目录
        /// </summary>
        public static string OptionConfigSitePrefix { get { return "~/OptionConfig"; } }

        /// <summary>
        /// "RootConfig"
        /// </summary>
        public static readonly string RootNode = "RootConfig";

        /// <summary>
        /// "item"
        /// </summary>
        public static readonly string NodeItem = "item";

        /// <summary>
        /// "name"
        /// </summary>
        public static readonly string NodeItemName = "name";

        /// <summary>
        /// "value"
        /// </summary>
        public static readonly string NodeItemValue = "value";

        /// <summary>
        /// 全局的可选应用程序配置信息保存文件在站点服务器上的物理路径
        /// </summary>
        public static string OptionConfigWebFileName
        {
            get
            {
                return System.Web.HttpContext.Current.Server.MapPath(OptionConfigSitePrefix + "/" + OptionConfigFileName);
            }
        }

        /// <summary>
        /// 全局的可选应用程序配置信息保存文件的物理路径
        /// </summary>
        public static string OptionConfigAppFileName
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), OptionConfigFileName);
            }
        }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public string OptionConfigFile
        {
            get
            {
                switch (OptionConfigType)
                {
                    case EnOptionConfigType.Web:
                        return OptionConfigWebFileName;
                    case EnOptionConfigType.App:
                        return OptionConfigAppFileName;
                    case EnOptionConfigType.Optional:
                        return _optConfigFile;
                    default:
                        return OptionConfigWebFileName;
                }
            }
        }

        private EnOptionConfigType _OptionConfigType = EnOptionConfigType.Web;

        /// <summary>
        /// 配置应用于的程序类型
        /// </summary>
        public EnOptionConfigType OptionConfigType { get { return _OptionConfigType; } set { _OptionConfigType = value; } }

        /// <summary>
        /// 获取全局的可选应用程序配置的XDocument操作对象
        /// </summary>
        /// <returns>可选应用程序配置的XDocument操作对象</returns>
        protected internal XDocument CreateOptionConfigFile()
        {
            XDocument xdoc = null;
            var pth = string.Empty;

            switch (OptionConfigType)
            {
                case EnOptionConfigType.Web:
                    var pdir = System.Web.HttpContext.Current.Server.MapPath(OptionConfigSitePrefix);
                    if (!pdir.FileExists()) Directory.CreateDirectory(pdir);
                    pth = OptionConfigWebFileName;
                    break;
                case EnOptionConfigType.App:
                    pth = OptionConfigAppFileName;
                    break;
                case EnOptionConfigType.Optional:
                    pth = _optConfigFile;
                    break;
                default:
                    break;
            }
            if (!pth.FileExists())//不存在就创建
            {
                xdoc = new XDocument(new XElement(RootNode));
                xdoc.Save(pth);
            }
            else
                xdoc = XDocument.Load(pth);
            return xdoc;
        }

        /// <summary>
        /// 对配置节进行迭代
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">迭代函数</param>
        /// <returns>迭代函数返回的集合</returns>
        public IList<T> Each<T>(Func<XElement, T> func)
        {
            if (null == func) return null;
            var xdoc = CreateOptionConfigFile();
            var xe = xdoc.Element(RootNode);
            var xel = xe.Elements(NodeItem);
            if (null == xel) return null;
            var lst = new List<T>(xel.Count());
            xel.ToList().ForEach(k =>
            {
                lst.Add(func(k));
            });
            return lst;
        }

        /// <summary>
        /// 对配置节进行迭代，并以Json反序列化的方式返指定类型的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> EachDef<T>()
        {
            return Each<T>(ki =>
            {
                return GetCData<T>(ki.Attribute(NodeItemName).Value);
            }).ToList();
        }

        /// <summary>
        /// 将配置保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName">配置标识名称</param>
        /// <param name="value">配置值</param>
        /// <returns></returns>
        public IOptionConfig Set<T>(string keyName, T value)
        {
            var xdoc = CreateOptionConfigFile();
            var xe = FindItem(keyName, xdoc);
            if (null == xe)
            {
                xdoc.Element(RootNode).Add(new XElement(NodeItem, new XAttribute(NodeItemName, keyName), new XAttribute(NodeItemValue, value.ToString())));
            }
            else
            {
                xe.Attribute(NodeItemValue).Value = value.ToString();
            }
            xdoc.Save(OptionConfigFile);
            return this;
        }

        /// <summary>
        /// 写入CDATA数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName">节点名称</param>
        /// <param name="value">CDATA数据</param>
        /// <returns></returns>
        public IOptionConfig SetCData<T>(string keyName, T value)
        {
            var xdoc = CreateOptionConfigFile();
            var xe = FindItem(keyName, xdoc);
            XCData d = new XCData(ObjectHelper.SerializeJson(value));
            if (null == xe)
            {
                xdoc.Element(RootNode).Add(new XElement(NodeItem, new XAttribute(NodeItemName, keyName),
                    d
                    ));
            }
            else
            {
                ((XCData)(xe.FirstNode)).Value = d.Value;
                //xe.Value=d.Value;
            }
            xdoc.Save(OptionConfigFile);
            return this;
        }

        /// <summary>
        /// 移除指定的节点
        /// </summary>
        /// <param name="keyName">节点名称列表</param>
        /// <returns></returns>
        public IOptionConfig Remove(List<string> keyName)
        {
            var xdoc = CreateOptionConfigFile();
            keyName.ForEach(k =>
            {
                if (!string.IsNullOrEmpty(k))
                {
                    var xe = FindItem(k, xdoc);
                    if (null != xe)
                        xe.Remove();
                }
            });
            xdoc.Save(OptionConfigFile);
            return this;
        }

        /// <summary>
        /// 移除指定的节点
        /// </summary>
        /// <param name="keyName">节点名称</param>
        /// <returns></returns>
        public IOptionConfig Remove(string keyName)
        {
            if (string.IsNullOrEmpty(keyName)) return this;
            var xdoc = CreateOptionConfigFile();
            var xe = FindItem(keyName, xdoc);
            if (null == xe) return this;
            xe.Remove();
            xdoc.Save(OptionConfigFile);
            return this;
        }
        
        /// <summary>
        /// 读取配置值
        /// NOTE:如果指定的类型不存在则返回T类型对应的默认值(对于引用类型则为null)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName">配置标识名称</param>
        /// <param name="fnc">反序列化回调,若不为null则调用此回调.否则默认执行json反序列化</param>
        /// <returns>配置值</returns>
        public T GetCData<T>(string keyName, Func<string, T> fnc = null)
        {
            var xdoc = CreateOptionConfigFile();
            var xe = FindItem(keyName, xdoc);
            if (null == xe) return default(T);
            var kv = xe.Value;
            if (null == fnc)
                return ObjectHelper.DeSerialize<T>(kv);
            else
                return fnc(kv);
        }

        /// <summary>
        /// 查找与指定关键字匹配的节点
        /// </summary>
        /// <param name="keyname">配置名称标识</param>
        /// <returns>匹配的节点</returns>
        public virtual XElement FindItem(string keyname, XDocument doc = null)
        {
            var xdoc = null == doc ? CreateOptionConfigFile() : doc;
            var xe = xdoc.Element(RootNode);
            var xel = xe.Elements(NodeItem);
            if (null == xel) return null;
            xel = xel.Where(k => k.HasAttributes && k.Attribute(NodeItemName).Value == keyname);
            if (null == xel || xel.Count() < 1) return null;
            return xel.First();
        }


        /// <summary>
        /// 读取配置值
        /// NOTE:如果指定的类型不存在则返回T类型对应的默认值(对于引用类型则为null,对于值类型则取决于具体的值类型)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName">配置标识名称</param>
        /// <returns>配置值</returns>
        public T Get<T>(string keyName)
        {
            var xdoc = CreateOptionConfigFile();
            var xe = FindItem(keyName, xdoc);
            if (null == xe) return default(T);
            var kv = xe.Attribute(NodeItemValue).Value;
            if (string.IsNullOrEmpty(kv)) return default(T);
            return (T)(Convert.ChangeType(kv, typeof(T)));
        }
    }

    public enum EnOptionConfigType
    {
        /// <summary>
        /// For Web
        /// </summary>
        Web = 0,

        /// <summary>
        /// For App
        /// </summary>
        App = 1,

        /// <summary>
        /// For Custom Define
        /// </summary>
        Optional = 2,
    }
}
