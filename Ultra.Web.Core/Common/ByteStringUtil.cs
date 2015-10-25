using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// 字节数组与字符串转换帮助类
    /// </summary>
    [Serializable]
    public class ByteStringUtil
    {
        /// <summary>
        /// 将十六进制长串 每两个字符解释为一个字节 转换为对应的字节数组返回
        /// </summary>
        /// <param name="hexStr">十六进制串若带前缀</param>
        /// <returns>转换为对应的字节数组,若转换失败返回null</returns>
        public static byte[] ByteArrayFromHexStr(string hexStr)
        {
            if (string.IsNullOrEmpty(hexStr))
                return null;
            if (hexStr.Length % 2 != 0)
                return null;
            if (hexStr.StartsWith("0x") || hexStr.StartsWith("0X"))
                hexStr = hexStr.Substring(2, hexStr.Length - 2);

            byte[] bytary = new byte[hexStr.Length / 2];
            char[] chrs = hexStr.ToCharArray();
            for (int i = 0, j = 0; i < chrs.Length; i += 2, j++)
                bytary[j] = Convert.ToByte(chrs[i] + string.Empty + chrs[i + 1] + string.Empty, 16);
            return bytary;
        }

        /// <summary>
        /// 将字节数组转换为对应的十六进制串,每一个字节转换为两个字符
        /// </summary>
        /// <param name="bytdata">字节数组</param>
        /// <returns>转换后的十六进制字符串,若转换失败则返回string.Empty</returns>
        public static string ByteArrayToHexStr(byte[] bytdata)
        {
            if (null == bytdata || bytdata.Length < 1)
                return string.Empty;
            StringBuilder sb = new StringBuilder(256);
            foreach (byte byt in bytdata)
            {
                sb.Append(string.Format("{0:X2}", byt));
            }
            return sb.ToString();
        }
    }
}
