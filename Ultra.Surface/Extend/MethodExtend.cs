using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ultra.Surface.Extend
{
    /// <summary>
    /// 控件扩展方法集
    /// </summary>
    public static class MethodExtend
    {
        public static TResult CopyEx<TSrc, TResult>(this TSrc oj)
            where TSrc : class, new()
            where TResult : class, new() {
                return Ultra.Web.Core.Common.ObjectHelper.DeSerialize<TResult>(Ultra.Web.Core.Common.ObjectHelper.SerializeJson(oj));
        }

        public static List<TResult> CopyEx<TSrc, TResult>(this List<TSrc> oj)
            where TSrc : class, new()
            where TResult : class, new() {
            if (oj == null) {
                return null;
            }
            List<TResult> list = new List<TResult>(oj.Count);
            for (int i = 0; i < oj.Count; i++) {
                list.Add(oj[i].CopyEx<TSrc, TResult>());
            }
            return list;
        }

        public static bool IsNullOrEmpty(this DataTable dt) {
            return (dt == null || dt.Rows.Count <= 0) ? true :false;
        }

        public static bool IsNullOrEmpty<T>(this List<T> lst) {
            return (lst == null || lst.Count <= 0) ? true : false;
        }

        /// <summary>
        /// 不选中任何行
        /// </summary>
        public static void ReleaseFocusedRow(this DevExpress.XtraGrid.Views.Grid.GridView gdview)
        {
            if (null != gdview)
                gdview.FocusedRowHandle = -999997;
        }

        /// <summary>
        /// 获取数据源对象实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static List<T> GetDataSource<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview)
        {
            if (null == gdview) return null;
            return gdview.DataSource as List<T>;
        }

        /// <summary>
        /// 获取选中行的数据对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static T GetFocusedDataSource<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview)
        {
            if (null == gdview) return default(T);
            return (T)gdview.GetRow(gdview.FocusedRowHandle);
        }

        /// <summary>
        /// 获取指定行的数据对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T GetRowDataSource<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview, int row)
        {
            if (null == gdview) return default(T);
            return (T)gdview.GetRow(row);
        }

        /// <summary>
        /// 获取选中行的数据对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static T GetFocusedDataSource<T>(this DevExpress.XtraGrid.GridControl gc)
        {
            if (null == gc) return default(T);
            var gv = gc.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null == gv) return default(T);
            return GetFocusedDataSource<T>(gv);
        }

        /// <summary>
        /// 获取数据源对象实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static List<T> GetDataSource<T>(this DevExpress.XtraGrid.GridControl gc)
        {
            if (null == gc) return null;
            return gc.DataSource as List<T>;
        }

        /// <summary>
        /// 更新数据源的对象实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static void UpdateFocusedRow<T>(this DevExpress.XtraGrid.Views.Grid.GridView gv, T mod)
        {
            if (null == gv || gv.FocusedRowHandle < 0)
                return;
            var lst = gv.GetDataSource<T>();
            var et = gv.GetFocusedDataSource<T>();
            var idx = lst.IndexOf(et);
            lst.Remove(et);
            lst.Insert(idx, mod);
            gv.GridControl.RefreshDataSource();
        }

        /// <summary>
        /// 获取所选行的数据对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gdview"></param>
        /// <returns></returns>
        public static List<T> GetSelectedDataSource<T>(this DevExpress.XtraGrid.Views.Grid.GridView gdview) {
            var idxs = gdview.GetSelectedRows();
            if (null == idxs || idxs.Length < 1) return null;
            return idxs.ToList().Select(j => (T)gdview.GetRow(j)).ToList();
        }

        /// <summary>
        /// 移除选中的行
        /// </summary>
        /// <param name="gc"></param>
        public static void RemoveSelected(this DevExpress.XtraGrid.GridControl gc) {
            var gv = gc.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null == gv) return;
            gv.DeleteSelectedRows();
        }

        /// <summary>
        /// 根据指定的筛选条件移除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gc"></param>
        /// <param name="fnc"></param>
        public static List<T> RemoveByKey<T>(this DevExpress.XtraGrid.GridControl gc, Func<T, bool> fnc) {
            var kt = GetDataSource<T>(gc);
            if (null == kt || kt.Count < 1) return null;
            var jt = kt.Where(j => fnc(j)).ToList();
            jt.ForEach(j => kt.Remove(j));
            gc.DataSource = kt;
            gc.RefreshDataSource();
            return jt;
        }
    }

}
