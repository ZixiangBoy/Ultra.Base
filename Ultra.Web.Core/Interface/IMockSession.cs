/********************************************************************	
	created:	 2012-09-18
	author:		Szy
	contract	yanswer@msn.com
	company:	Ultra.Company	
	purpose:	通过cookie模拟的Session实现的接口定义
	project code: Ultra
	history:	
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultra.Web.Core.Interface
{
    /// <summary>
    /// 通过cookie模拟的Session实现的接口定义
    /// </summary>
    public interface IMockSession
    {
        object this[string key]
        {
            get;
            set;
        }

        /// <summary>
        /// 获取所有的键
        /// </summary>
        IEnumerable<string> AllKeys { get; }

        /// <summary>
        /// 序列化对象为Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string SeriesObjectJson(object obj);
    }

    /// <summary>
    /// 支持存储序列化对象的Cookie扩展/增强
    /// </summary>
    public interface IUltraCookie<T>
    {
        T this[string key] { get; set; }

        /// <summary>
        /// 获取所有的键
        /// </summary>
        IEnumerable<string> AllKeys { get; }


        /// <summary>
        /// 序列化对象为Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string SeriesObjectJson(object obj);

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsvlu"></param>
        /// <returns></returns>
        T DeSeriesObject<T>(string jsvlu);
    }
}
