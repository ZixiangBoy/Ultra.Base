using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// 摘要算法枚举
    /// </summary>
    public enum DigestType : short
    {
        MD5 = 0,
        SHA1 = 1,
        SHA256 = 2,
        SHA384 = 3,
        SHA512 = 4,
        RIPEMD160 = 5,
    }

    /// <summary>
    /// 摘要算法辅助类
    /// </summary>
    [Serializable]
    public sealed class HashDigest
    {
        public static HashAlgorithm GetHashAlgorithmByType(DigestType dgType)
        {
            HashAlgorithm ha = null;
            switch (dgType)
            {
                case DigestType.MD5:
                    ha = MD5.Create();
                    break;
                case DigestType.SHA1:
                    ha = SHA1.Create();
                    break;
                case DigestType.SHA256:
                    ha = SHA256.Create();
                    break;
                case DigestType.SHA384:
                    ha = SHA384.Create();
                    break;
                case DigestType.SHA512:
                    ha = SHA512.Create();
                    break;
                case DigestType.RIPEMD160:
                    ha = RIPEMD160.Create();
                    break;
            }
            return ha;
        }

        /// <summary>
        /// 获取文件哈希值
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="dgType">指定哈希算法</param>
        /// <returns>成功返回计算得到的哈希字节数组,否则为null</returns>
        public static byte[] FileDigest(string filePath, DigestType dgType)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath)) return null;

            Stream sr = File.OpenRead(filePath);
            HashAlgorithm ha = GetHashAlgorithmByType(dgType);
            byte[] hashbyt = ha.ComputeHash(sr);
            sr.Close();
            return hashbyt;
        }

        /// <summary>
        /// 获取文件MD5哈希值
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>成功返回计算得到的哈希字节数组,否则为null</returns>
        public static byte[] FileDigest(string filePath)
        {
            return FileDigest(filePath, DigestType.MD5);
        }

        /// <summary>
        /// 计算字符串哈希
        /// </summary>
        /// <param name="strSrc">欲计算哈希的字符串</param>
        /// <param name="dgType">指定哈希算法</param>
        /// <returns>成功返回计算得到的哈希字节数组,否则为null</returns>
        public static byte[] StringDigest(string strSrc, DigestType dgType)
        {
            byte[] bytsrc = Encoding.Default.GetBytes(strSrc);
            HashAlgorithm ha = GetHashAlgorithmByType(dgType);
            return ha.ComputeHash(bytsrc);
        }

        /// <summary>
        /// 计算字符串MD5哈希
        /// </summary>
        /// <param name="strSrc">欲计算哈希的字符串</param>
        /// <returns>成功返回计算得到的哈希字节数组,否则为null</returns>
        public static byte[] StringDigest(string strSrc)
        {
            return StringDigest(strSrc, DigestType.MD5);
        }
    }
}
