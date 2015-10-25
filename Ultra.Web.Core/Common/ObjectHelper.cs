using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// 对象操作帮助类
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// 取得所有公共属性
        /// </summary>        
        /// <param name="t">类型变量</param>
        /// <returns>取得所有公共属性</returns>
        public static PropertyInfo[] GetAllProperty(Type t)
        {
            PropertyInfo[] ptys = t.GetProperties();//取得所有公共属性
            return ptys;
        }

        /// <summary>
        /// 取得所有公共属性
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>取得所有公共属性</returns>
        public static PropertyInfo[] GetProPerty<T>()
        {
            PropertyInfo[] ptys = typeof(T).GetProperties();//取得所有公共属性
            return ptys;
        }

        /// <summary>
        /// 取得所有公共字段
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>取得所有公共字段</returns>
        public static FieldInfo[] GetField<T>()
        {
            FieldInfo[] fields = typeof(T).GetFields();//取得所有公共字段
            return fields;
        }

        /// <summary>
        /// 取得所有公共字段
        /// </summary>
        /// <param name="t">类型变量</param>
        /// <returns>取得所有公共字段</returns>
        public static FieldInfo[] GetAllField(Type t)
        {
            FieldInfo[] fields = t.GetFields();//取得所有公共字段
            return fields;
        }

        /// <summary>
        /// 反射自身类型以设置自身属性值
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns></returns>
        public static T ResloveSelfProperty<T>(DataRow dr) where T :  new()
        {
            Guid gid = Guid.Empty;
            T ins = new T();
            Type typ = ins.GetType();
            PropertyInfo ptyInfo;
            foreach (DataColumn dcl in dr.Table.Columns)
            {
                if (null == (ptyInfo = typ.GetProperty(dcl.ColumnName)))
                    continue;
                Type coltyp = ptyInfo.PropertyType;
                //可空类型
                if (coltyp.IsGenericType && coltyp.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    coltyp = coltyp.GetGenericArguments()[0];
                }
                object ptyValue = dr[dcl.ColumnName] == DBNull.Value ? null : dr[dcl.ColumnName];
                if (null == ptyValue) continue;
                //if (null != (ptyInfo = typ.GetProperty(dcl.ColumnName)))
                ptyInfo.SetValue(
                            ins,
                            (typeof(Guid) != coltyp) ?
                            Convert.ChangeType(ptyValue, coltyp) :
                            Guid.Parse(string.IsNullOrEmpty(ptyValue.ToString()) ? Guid.Empty.ToString() : ptyValue.ToString()),
                            null);
            }
            return ins;
        }

        /// <summary>
        /// 根据 dr 给定的DataRow数据创建实例
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>创建的实例,若dr无数据或dr为null则返回null</returns>
        public static T Create<T>(DataRow dr) where T :  new()
        {
            if (null == dr) return default(T);
            if (dr.Table.Columns.Count < 1) return default(T);
            return ResloveSelfProperty<T>(dr);
        }

        /// <summary>
        /// 根据 drs 给定的DataRow数据创建T的List实例集
        /// </summary>
        /// <param name="drs">DataRow数据</param>
        /// <returns>创建T的List实例集,若drs长度为0或drs为null则返回null</returns>
        public static List<T> Create<T>(DataRow[] drs) where T : new()
        {
            if (null == drs || drs.Length < 1) return null;
            List<T> lst = new List<T>(drs.Length);
            foreach (DataRow dr in drs)
            {
                lst.Add(Create<T>(dr));
            }
            return lst;
        }

        /// <summary>
        /// 根据 drcolection 给定的DataRow数据创建T的List实例集
        /// </summary>
        /// <param name="drcolection">DataRow数据</param>
        /// <returns>创建T的List实例集,若drs长度为0或drs为null则返回null</returns>
        public static List<T> Create<T>(DataRowCollection drcolection) where T : new()
        {
            if (null == drcolection || drcolection.Count < 1) return null;
            List<T> lst = new List<T>(drcolection.Count);
            foreach (DataRow dr in drcolection)
                lst.Add(Create<T>(dr));
            return lst;
        }

        /// <summary>
        /// 根据 dt 给定的DataRow数据创建T的List实例集
        /// </summary>
        /// <param name="drcolection">DataRow数据</param>
        /// <returns>创建T的List实例集,若drs长度为0或drs为null则返回null</returns>
        public static List<T> Create<T>(DataTable dt) where T :/*FrameWorkBaseEntity,*/ new()
        {
            if (null == dt) return null;
            return Create<T>(dt.Rows);
        }

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T objs)
        {
            IFormatter ift = new BinaryFormatter();
            byte[] byts = null;
            using (MemoryStream ms = new MemoryStream())
            {
                ift.Serialize(ms, objs);
                byts = ms.GetBuffer();
            }
            return byts;
        }

        /// <summary>
        /// 序列化对象为Json串
        /// </summary>
        /// <param name="obj">要被序列化的对象</param>
        /// <returns></returns>
        public static string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="jsonstr">Json串</param>
        /// <returns></returns>
        public static T DeSerialize<T>(string jsonstr)
        {
            return JsonConvert.DeserializeObject<T>(jsonstr);
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="byts"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(byte[] byts)
        {
            IFormatter ift = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(byts))
            {
                return (T)ift.Deserialize(ms);
            }
        }

        /// <summary>
        /// 深表复制对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objsrc"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(T objsrc)
        {
            if (null == objsrc) return objsrc;
            return DeSerialize<T>(Serialize<T>(objsrc));
        }

        #region 反射识别类型

        /// <summary>
        /// 判断指定的类型是否实现某个接口
        /// </summary>
        /// <param name="interfaceName">接口名称</param>
        /// <param name="t">欲判断的类型</param>
        /// <returns>类型是否实现接口，实现返回true否则为false</returns>
        public static bool IsInheritInterface(string interfaceName,Type t)
        {
            return null != t.GetInterface(interfaceName, true);
        }

        /// <summary>
        /// 判断类型 t 是否是 tbase的子类
        /// </summary>
        /// <param name="tbase"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsInheritClass(Type tbase, Type t)
        {
            return t.IsSubclassOf(tbase);
        }

        /// <summary>
        /// 从指定程序集中获取继承指定接口的所有类型
        /// 若接口类型名称为空则获取所有类型
        /// </summary>
        /// <param name="asmFile">程序集路径</param>
        /// <param name="interfaceName">接口类型名称默认为空</param>
        /// <returns>获取继承指定接口的所有类型</returns>
        public static List<Type> GetAllClassOfInterface(string asmFile, string interfaceName = "")
        {
            if (!File.Exists(asmFile)) return null;
            var asm= LoadAsm(asmFile);
            return GetAllClassOfInterface(asm, interfaceName);
        }

        /// <summary>
        /// 从指定程序集中获取继承指定接口的所有类型
        /// 若接口类型名称为空则获取所有类型
        /// </summary>
        /// <param name="asm">程序集</param>
        /// <param name="interfaceName">接口类型名称默认为空</param>
        /// <returns>获取继承指定接口的所有类型</returns>
        public static List<Type> GetAllClassOfInterface(Assembly asm, string interfaceName = "")
        {
            if (null == asm) return null;
            var tps = asm.GetTypes();
            if (string.IsNullOrEmpty(interfaceName)) return tps.ToList();
            return tps.Where(k => IsInheritInterface(interfaceName, k)).ToList();
        }

        /// <summary>
        /// 从指定程序集中获取继承指定类的所有类型
        /// </summary>
        /// <param name="tbase">基类类型</param>
        /// <param name="asmFile">程序集路径</param>
        /// <returns>继承指定类的所有类型</returns>
        public static List<Type> GetAllClassOfClass(Type tbase, string asmFile)
        {
            if (!File.Exists(asmFile)) return null;
            var asm = LoadAsm(asmFile);
            return GetAllClassOfClass(tbase, asm);
        }

        /// <summary>
        /// 从指定程序集中获取继承指定类的所有类型
        /// </summary>
        /// <param name="tbase">基类类型</param>
        /// <param name="asm">程序集</param>
        /// <returns>继承指定类的所有类型</returns>
        public static List<Type> GetAllClassOfClass(Type tbase, Assembly asm)
        {
            if (null == asm) return null;            
            var tps = asm.GetTypes();
            if (null == tbase) return tps.ToList();
            return tps.Where(k => IsInheritClass(tbase, k)).ToList();
        }

        /// <summary>
        /// 装载程序 集 (内存装载，不占用文件锁)
        /// </summary>
        /// <param name="asmFile"></param>
        /// <returns></returns>
        internal static Assembly LoadAsm(string asmFile)
        {
            Assembly asm =
#if DEBUG
 Assembly.LoadFile(asmFile);
#else
            Assembly.Load(File.ReadAllBytes(asmFile));
#endif
            return asm;
        }

        /// <summary>
        /// 获取属性的描述
        /// </summary>
        /// <param name="pi">属性数据</param>
        /// <returns>属性的描述</returns>
        public static string GetPropertyDesc(PropertyInfo pi)
        {
            if (null == pi) return string.Empty;
            var atr = pi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
            if (null == atr || atr.Count() < 1) return string.Empty;
            var a = atr.First() as System.ComponentModel.DescriptionAttribute;
            if (null == a) return string.Empty;
            return a.Description;
        }

        /// <summary>
        /// 获取字段描述
        /// </summary>
        /// <param name="fi">字段</param>
        /// <returns>字段描述</returns>
        public static string GetFieldDesc(FieldInfo fi)
        {
            if (null == fi) return string.Empty;
            var atr = fi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
            if (null == atr || atr.Count() < 1) return string.Empty;
            var a = atr.First() as System.ComponentModel.DescriptionAttribute;
            if (null == a) return string.Empty;
            return a.Description;
        }

        /// <summary>
        /// 判断属性类型是否为可空
        /// </summary>
        /// <param name="pi">属性</param>
        /// <returns>不是可空则返回true否则为false</returns>
        public static bool IsRequired(PropertyInfo pi)
        {
            if (null == pi) return false;
            var pit = pi.PropertyType;
            return !(pit.IsGenericType && pit.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// 判断字段类型是否为可空
        /// </summary>
        /// <param name="fi">字段</param>
        /// <returns>不是可空则返回true否则为false</returns>
        public static bool IsRequired(FieldInfo fi)
        {
            if (null == fi) return false;
            var pit = fi.FieldType;
            return (pit.IsGenericType && pit.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// 获取类型表示文字
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static string GetTypeUseage(PropertyInfo pi)
        {
            var b = IsRequired(pi);
            if (!b)
                return pi.PropertyType.GetGenericArguments()[0].FullName + "?";
            else
                return pi.PropertyType.Name;
        }

        /// <summary>
        /// 获取类型表示文字
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static string GetTypeUseage(FieldInfo fi)
        {
            var b = IsRequired(fi);
            if (b)
                return fi.FieldType.GetGenericArguments()[0].FullName + "?";
            else
                return fi.FieldType.Name;
        }

        #endregion

        #region For Gen

        /// <summary>
        /// 判断属性类型是否为数值
        /// </summary>
        /// <param name="pi">属性</param>
        /// <returns></returns>
        public static bool IsNumber(PropertyInfo pi)
        {
            var t= pi.PropertyType;
            return t == typeof(int) || t == typeof(int?) ||
                t == typeof(Int32) || t == typeof(Int32?) ||
                t == typeof(Int64) || t == typeof(Int64?) ||
                t == typeof(Int16) || t == typeof(Int16?) ||
                t == typeof(uint) || t == typeof(uint?) ||
                t == typeof(float) || t == typeof(float?) ||
                t == typeof(double) || t == typeof(double?) ||
                t == typeof(Double) || t == typeof(Double?) ||
                t == typeof(UInt16) || t == typeof(UInt16?) ||
                t == typeof(UInt32) || t == typeof(UInt32?) ||
                t == typeof(UInt64) || t == typeof(UInt64?) ||
                t == typeof(decimal) || t == typeof(decimal?) ||
                t == typeof(Decimal) || t == typeof(Decimal?) ||
                t == typeof(sbyte) || t == typeof(sbyte?) ||
                t == typeof(SByte) || t == typeof(SByte?);
        }

        /// <summary>
        /// 判断属性是否是日期
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static bool IsDateTime(PropertyInfo pi)
        {
            var t = pi.PropertyType;
            return t == typeof(DateTime) ||
                t == typeof(DateTime?);
        }

        /// <summary>
        /// 是否布尔类型
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static bool IsBool(PropertyInfo pi)
        {
            var t = pi.PropertyType;
            return t == typeof(bool) || t == typeof(bool?);
        }

        /// <summary>
        /// 是否Guid类型
        /// </summary>
        /// <param name="pi">属性</param>
        /// <returns></returns>
        public static bool IsGuid(PropertyInfo pi)
        {
            var t = pi.PropertyType;
            return t == typeof(Guid) || t == typeof(Guid?);
        }

        #endregion
    }

    /// <summary>
    /// 動態類型創建工具
    /// 將類型的屬性創建為公有字段並填充值
    /// </summary>
    public static class DynamicFactory
    {
        private static ConcurrentDictionary<Type, Type> s_dynamicTypes = new ConcurrentDictionary<Type, Type>();

        private static Func<Type, Type> s_dynamicTypeCreator = new Func<Type, Type>(CreateDynamicType);

        public static object ToDynamic(this object entity)
        {
            var entityType = entity.GetType();
            var dynamicType = s_dynamicTypes.GetOrAdd(entityType, s_dynamicTypeCreator);

            var dynamicObject = Activator.CreateInstance(dynamicType);
            foreach (var entityProperty in entityType.GetProperties())
            {
                var value = entityProperty.GetValue(entity, null);
                dynamicType.GetField(entityProperty.Name).SetValue(dynamicObject, value);
            }

            return dynamicObject;
        }

        private static Type CreateDynamicType(Type entityType)
        {
            var asmName = new AssemblyName("DynamicAssembly_" + Guid.NewGuid());
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);
            var moduleBuilder = asmBuilder.DefineDynamicModule("DynamicModule_" + Guid.NewGuid());

            var typeBuilder = moduleBuilder.DefineType(
                entityType.GetType() + "$DynamicType",
                TypeAttributes.Public);

            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);

            foreach (var entityProperty in entityType.GetProperties())
            {
                typeBuilder.DefineField(entityProperty.Name, entityProperty.PropertyType, FieldAttributes.Public);
            }

            return typeBuilder.CreateType();
        }
    }
}
