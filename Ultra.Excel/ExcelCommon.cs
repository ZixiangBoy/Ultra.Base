using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultra.Excel {
    public static class ExcelCommon {
        public static List<T> ReadXls<T>(string fileName, Dictionary<string, string> fieldsMapper) where T : new() {
            var lst = new List<T>();
            var excelFile = new ExcelQueryFactory(fileName);
            var rows = from a in excelFile.Worksheet(0) select a;
            var t = typeof(T);
            var props = t.GetProperties().Where(k=>fieldsMapper.Keys.Any(j=>j==k.Name));
            foreach (var a in rows) {
                T item = new T();
                foreach (var prop in props) {
                    Type ftyp = prop.PropertyType;
                    //可空类型
                    if (ftyp.IsGenericType && ftyp.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                        ftyp = ftyp.GetGenericArguments()[0];
                    }
                    object propVal = a[fieldsMapper[prop.Name]].Value;
                    prop.SetValue(item, Convert.ChangeType(propVal, ftyp), null);
                }
                lst.Add(item);
            }
            return lst;
        }
    }
}
