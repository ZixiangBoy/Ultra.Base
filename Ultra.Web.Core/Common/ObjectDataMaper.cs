using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// 实体对象与DataTable的映射转换帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ObjectDataMaper<T>
    {
        private static ObjectDataMaper<T> _ent = new ObjectDataMaper<T>();

        /// <summary>
        /// 实体的静态唯一实例
        /// </summary>
        public static ObjectDataMaper<T> Entity
        {
            get
            {
                return _ent;
            }
        }

        /// <summary>
        /// 根据类型获取类型对应的DataTable结构
        /// NOTE:会将类型中所有的公共属性反应到返回DataTable中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public DataTable GetDataTableSechma()
        {
            PropertyInfo[] ptys = typeof(T).GetProperties();
            if (null == ptys || ptys.Length < 1) return null;
            DataTable dt = new DataTable();
            foreach (var item in ptys)
            {
                //可空类型
                if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType.GetGenericArguments()[0]));
                else
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType));
            }
            return dt;
        }

        /// <summary>
        /// 根据类型获取类型对应的DataTable结构
        /// NOTE:会将参数中指定的公共属性或公共字段反射到返回DataTable中
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSechmaEx(string[] propOrFields)
        {
            if (null == propOrFields || propOrFields.Length < 1) return null;
            PropertyInfo[] ptys = typeof(T).GetProperties();//取得所有公共属性
            FieldInfo[] fields = typeof(T).GetFields();//取得所有公共字段
            var pts = ptys.Where(i => propOrFields.Any(j => j == i.Name)).ToList();//取得所有匹配的属性
            var fieds = fields.Where(i => propOrFields.Any(j => j == i.Name)).ToList();//取得所有匹配的字段
            DataTable dt = new DataTable();
            foreach (var item in pts)
            {
                //可空类型
                if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType.GetGenericArguments()[0]));
                else
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType));
            }
            foreach (var item in fieds)
            {
                //可空类型
                if (item.FieldType.IsGenericType && item.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    dt.Columns.Add(new DataColumn(item.Name, item.FieldType.GetGenericArguments()[0]));
                else
                    dt.Columns.Add(new DataColumn(item.Name, item.FieldType));
            }
            return dt;
        }

        /// <summary>
        /// 根据类型获取类型对应的DataTable结构
        /// NOTE:会将类型中所有的公共属性反应到返回DataTable中
        /// </summary>
        public static DataTable TableSechma
        {
            get
            {
                PropertyInfo[] ptys = typeof(T).GetProperties();
                if (null == ptys || ptys.Length < 1) return null;
                DataTable dt = new DataTable();
                foreach (var item in ptys)
                {
                    //可空类型
                    if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        dt.Columns.Add(new DataColumn(item.Name, item.PropertyType.GetGenericArguments()[0]));
                    else
                        dt.Columns.Add(new DataColumn(item.Name, item.PropertyType));
                }
                return dt;
            }
        }

        /// <summary>
        /// 根据类型获取类型对应的DataTable结构
        /// </summary>
        /// <param name="propertyArgs">欲反射到返回的DataTable中的属性字段名称(区分大小写)</param>
        /// <returns></returns>
        public static DataTable DataTableSechma(params string[] propertyArgs)
        {
            if (null == propertyArgs || propertyArgs.Length < 1) return TableSechma;
            PropertyInfo[] ptys = typeof(T).GetProperties();
            if (null == ptys || ptys.Length < 1) return null;
            var r = (from itm in ptys
                join a in propertyArgs on itm.Name equals a
                select itm).ToList();
            if (null == r || r.Count < 1) return null;
            DataTable dt = new DataTable();
            foreach (var item in r)
            {
                //可空类型
                if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType.GetGenericArguments()[0]));
                else
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType));
            }
            return dt;
        }

        /// <summary>
        /// 根据类型获取类型对应的DataTable结构
        /// NOTE:会将参数中指定的公共属性或公共字段反射到返回DataTable中
        /// </summary>
        /// <param name="propOrFields"></param>
        /// <returns></returns>
        public static DataTable DataTableSechmaEx(string[] propOrFields, out List<PropertyInfo> propList, out List<FieldInfo> fieldList)
        {
            propList = null; fieldList = null;
            if (null == propOrFields || propOrFields.Length < 1) return null;
            PropertyInfo[] ptys = typeof(T).GetProperties();//取得所有公共属性
            FieldInfo[] fields = typeof(T).GetFields();//取得所有公共字段
            var pts = ptys.Where(i => propOrFields.Any(j => j == i.Name)).ToList();//取得所有匹配的属性
            var fieds = fields.Where(i => propOrFields.Any(j => j == i.Name)).ToList();//取得所有匹配的字段
            fieldList = fieds.ToList();
            propList = pts.ToList();
            DataTable dt = new DataTable();
            foreach (var item in fieds)
            {
                //可空类型
                if (item.FieldType.IsGenericType && item.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    dt.Columns.Add(new DataColumn(item.Name, item.FieldType.GetGenericArguments()[0]));
                else
                    dt.Columns.Add(new DataColumn(item.Name, item.FieldType));
            }
            foreach (var item in pts)
            {
                if (dt.Columns.Contains(item.Name)) continue;
                //可空类型
                if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType.GetGenericArguments()[0]));
                else
                    dt.Columns.Add(new DataColumn(item.Name, item.PropertyType));
            }
            return dt;
        }
    }
}
