/********************************************************************	
	created:	 2012-09-18
	author:		Wakaka
	contract	wakaka_wka@msn.com
	company:	Ultra.Company	
	purpose:	支持序列化对象的cookie
	project code: Ultra
	history:	
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Ultra.Web.Core.Interface;

namespace Ultra.Web.Core.Class
{
    /// <summary>
    /// 支持序列化对象的cookie
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class UltraCookie<T> : IUltraCookie<T>
    {

        protected static UltraCookie<T> _Index = new UltraCookie<T>();

        /// <summary>
        /// 静态索引器 避免使用本类时重复创建对象
        /// </summary>
        public static UltraCookie<T> Index { get { return _Index; } }

        #region IUltraCookie<T> 成员

        /// <summary>
        /// 设置/返回对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T this[string key]
        {
            get
            {
                var obj = HttpContext.Current.Request.Cookies[key];
                if (null == obj) return default(T);
                if (string.IsNullOrEmpty(obj.Value)) return default(T);
                return DeSeriesObject<T>(obj.Value);
            }
            set
            {
                if (null == value)
                {
                    HttpContext.Current.Response.Cookies[key].Value = null; return;
                }

                HttpContext.Current.Response.Cookies[key].Value = SeriesObjectJson(value);
            }
        }

        /// <summary>
        /// 返回Cookie中的所有键名称
        /// </summary>
        public IEnumerable<string> AllKeys
        {
            get { return HttpContext.Current.Request.Cookies.AllKeys; }
        }

        /// <summary>
        /// 对象序列化方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string SeriesObjectJson(object obj)
        {
            if (null == obj) return string.Empty;
            return JsonConvert.SerializeObject(obj);
        }


        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsvlu"></param>
        /// <returns></returns>
        public T DeSeriesObject<T>(string jsvlu)
        {
            if (string.IsNullOrEmpty(jsvlu)) return default(T);
            return JsonConvert.DeserializeObject<T>(jsvlu);
        }

        #endregion

        
    }
}
