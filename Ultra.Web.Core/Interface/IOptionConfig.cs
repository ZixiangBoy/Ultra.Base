/********************************************************************	
   created:	2012-09-26
   author:	wakaka
   contract	wakaka_wka@live.com
   company:	Ultra.Company	
   purpose:	 自定义配置操作接口声明
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
    /// 自定义配置操作接口声明
    /// </summary>
    public interface IOptionConfig
    {
        /// <summary>
        /// 将配置保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName">配置标识名称</param>
        /// <param name="value">配置值</param>
        /// <returns></returns>
        IOptionConfig Set<T>(string keyName, T value);

        /// <summary>
        /// 读取配置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName">配置标识名称</param>
        /// <returns>配置值</returns>
        T Get<T>(string keyName);
    }
}
