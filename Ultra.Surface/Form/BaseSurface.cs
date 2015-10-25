using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Interfaces;
using Ultra.Web.Core.Interface;
using Ultra.Web.Core.Cache;
using PetaPoco;

namespace Ultra.Surface.Form
{
    /// <summary>
    /// 基础画面基类
    /// </summary>
    public partial class BaseSurface : DevExpress.XtraEditors.XtraForm, IBusinessSurface  //, ISurfacePermission
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public BaseSurface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 配置读取器
        /// </summary>
        public virtual Ultra.Web.Core.Interface.IOptionConfig OptConfig
        {
            get;
            internal set;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public virtual string ConnString
        {
            get;
            internal set;
        }

        private Database _Db { get; set; }

        protected virtual Database Db {
            get {
                return _Db = _Db ?? new PetaPoco.Database();
            }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public virtual string CurUser
        {
            get
            {
                return this.Cacher.Get<string>("CurUser");
            }
        }

        /// <summary>
        /// 获取当前登录用户对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T GetCurUser<T>()
        {
            return this.Cacher.Get<T>("CurrentUser");
        }

        /// <summary>
        /// Guid 键值
        /// </summary>
        public virtual Guid GuidKey { get; set; }

        /// <summary>
        /// Id 键值
        /// </summary>
        public virtual int IdKey { get; set; }

        public ICache Cacher {
            get;
            set;
        }

        public Web.Core.Enums.EnViewEditMode EditMode {
            get;
            set;
        }

        public object CallBack(params object[] args) {
            throw new NotImplementedException();
        }

    }
}
