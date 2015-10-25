using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// RSA加密服务帮助类
    /// </summary>
    [Serializable]
    public class RSAEncrypt
    {
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="srcData">源数据</param>
        /// <param name="keyPub">加密密钥</param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] srcData, string keyPub)
        {
            if (null == srcData || string.IsNullOrEmpty(keyPub) || srcData.Length < 1)
                return null;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            rsa.FromXmlString(keyPub);
            return rsa.Encrypt(srcData, false);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="srcData">源数据</param>
        /// <param name="keyPri">解密密钥</param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] srcData, string keyPri)
        {
            if (null == srcData || string.IsNullOrEmpty(keyPri) || srcData.Length < 1)
                return null;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            rsa.FromXmlString(keyPri);
            return rsa.Decrypt(srcData, false);
        }
    }
}
