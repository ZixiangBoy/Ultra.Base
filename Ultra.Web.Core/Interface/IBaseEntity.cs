using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultra.Web.Core.Interface
{
    /// <summary>
    /// 基础实现接口
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Guid
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// UI选中状态
        /// </summary>
        bool UISelected { get; set; }

        //byte[] Timestamp { get; set; }
    }
}
