/********************************************************************	
	created:	2012-09-18
	author:		Szy
	contract	yanswer@msn.com
	company:	Ultra.Company	
	purpose:	IMockSession接口的默认实现
	project code: Ultra
	history:	
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.Web.Core.Interface;
using Newtonsoft.Json;
using System.Web;
using Ultra.Web.Core.Common;
namespace Ultra.Web.Core.Class
{
    /// <summary>
    /// IMockSession接口的默认实现,用cookie模拟实现Session也即带超时的cookie 默认20分钟超时
    /// NOTE:要存放于MockSession中的类必须支持序列化与反序列化
    /// </summary>
    public partial class MockSession : IMockSession
    {
        protected int _ExpireMinute = 20;//默认20分钟超时

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="expireMinute">默认超时的分钟数</param>
        public MockSession(int expireMinute) { _ExpireMinute = expireMinute; }

        public MockSession() { }

        protected virtual string BuildCookieKey(string key)
        {
            return string.Format("{0}_Ultra_Cookie", key);
        }

        /// <summary>
        /// 内部用于记录key的字典
        /// </summary>
        protected Dictionary<string, object> dicKey = new Dictionary<string, object>(30);

        #region IMockSession 成员

        /// <summary>
        /// 索引器 类似Session般操作
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual object this[string key]
        {
            get
            {
                string ckKey = BuildCookieKey(key);
                if (!HttpContext.Current.Request.Cookies.AllKeys.Contains(ckKey)) return null;

                DateTime d = DateTime.Parse(HttpContext.Current.Request.Cookies[ckKey].Value);
                if (DateTime.Now.DateDiff(EnDatePart.MINUTE, d) > _ExpireMinute)//已超时
                    return null;
                string vlu = HttpContext.Current.Request.Cookies[key].Value;
                if (string.IsNullOrEmpty(vlu)) return null;
                HttpContext.Current.Request.Cookies[key].Expires = DateTime.Now.AddMinutes(_ExpireMinute);
                return JsonConvert.DeserializeObject(vlu);
            }
            set
            {
                string ckKey = BuildCookieKey(key);
                if (!dicKey.ContainsKey(ckKey))
                {
                    dicKey.Add(ckKey, value);
                }
                else
                {
                    dicKey[ckKey] = value;
                }
                HttpContext.Current.Response.Cookies[ckKey].Value = DateTime.Now.ToDefaultStr();
                HttpContext.Current.Response.Cookies[key].Value = SeriesObjectJson(value);
                var dt = DateTime.Now.AddMinutes(_ExpireMinute);
                HttpContext.Current.Response.Cookies[ckKey].Expires =dt;
                HttpContext.Current.Response.Cookies[key].Expires = dt;

            }
        }

        #endregion

        #region IMockSession 成员

        /// <summary>
        /// 所有的键
        /// </summary>
        public virtual IEnumerable<string> AllKeys
        {
            get
            {
                return HttpContext.Current.Request.Cookies.AllKeys;
            }
        }

        #endregion

        #region IMockSession 成员

        /// <summary>
        /// 序列化对象为Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual string SeriesObjectJson(object obj)
        {
            if (null == obj) return string.Empty;
            return JsonConvert.SerializeObject(obj);
        }

        #endregion
    }

    /// <summary>
    /// IMockSession接口的默认泛型实现,用cookie模拟实现Session也即带超时的cookie 默认20分钟超时
    /// NOTE:要存放于MockSession中的类必须支持序列化与反序列化
    /// </summary>
    /// <typeparam name="T">必须支持序列化与反序列化</typeparam>
    public partial class UltraMockSession<T> : MockSession
    {
        public UltraMockSession(int expireMinute) : base(expireMinute) { }

        public UltraMockSession() : base() { }

        protected static UltraMockSession<T> _Index = new UltraMockSession<T>();

        /// <summary>
        /// 静态索引器.避免使用本类时需要重复创建对象
        /// </summary>
        public static UltraMockSession<T> Index { get { return _Index; } }

        /// <summary>
        /// 索引器 类似Session般操作
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new T this[string key]
        {
            get
            {
                string ckKey = BuildCookieKey(key);
                if (!HttpContext.Current.Request.Cookies.AllKeys.Contains(ckKey)) return default(T);

                DateTime d = DateTime.Parse(HttpContext.Current.Request.Cookies[ckKey].Value);
                if (DateTime.Now.DateDiff(EnDatePart.MINUTE, d) > _ExpireMinute)//已超时
                    return default(T);
                string vlu = HttpContext.Current.Request.Cookies[key].Value;
                if (string.IsNullOrEmpty(vlu)) return default(T);
                HttpContext.Current.Request.Cookies[key].Expires = DateTime.Now.AddMinutes(_ExpireMinute);
                return JsonConvert.DeserializeObject<T>(vlu);
            }
            set
            {
                string ckKey = BuildCookieKey(key);
                if (!dicKey.ContainsKey(ckKey))
                {
                    dicKey.Add(ckKey, value);
                }
                else
                {
                    dicKey[ckKey] = value;
                }
                HttpContext.Current.Response.Cookies[ckKey].Value = DateTime.Now.ToDefaultStr();
                HttpContext.Current.Response.Cookies[key].Value = SeriesObjectJson(value);
                var dt = DateTime.Now.AddMinutes(_ExpireMinute);
                HttpContext.Current.Response.Cookies[ckKey].Expires = dt;
                HttpContext.Current.Response.Cookies[key].Expires = dt;
            }
        }

        /// <summary>
        /// 所有的键
        /// </summary>
        public override IEnumerable<string> AllKeys
        {
            get
            {
                return base.AllKeys;
            }
        }
    }

}
