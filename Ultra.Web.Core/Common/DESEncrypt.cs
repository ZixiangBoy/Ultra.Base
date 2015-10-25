
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// DES加解密帮助类
    /// </summary>
    [Serializable]
    public class DESEncrypt
    {
        //默认密钥向量
        private static byte[] Keys = { 0x8E, 0x3D, 0x18, 0xE8, 0x1E, 0xA1, 0x6F, 0x5F };

        /// <summary>
        /// 默认密钥
        /// </summary>
        private string DefaultKey
        {
            get
            {
                return
                   Encoding.Default.GetString(
                   HashDigest.StringDigest("Ultra.Web.Core.Common-Serct-Key", DigestType.MD5));
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="srcData">源数据</param>
        /// <param name="strKey">密钥</param>
        /// <returns>密文字节数组,若加密失败则返回null</returns>
        public byte[] Encrypt(byte[] srcData, string strKey)
        {
            //将密钥散列
            byte[] srcKeyData = HashDigest.StringDigest(strKey, DigestType.MD5);
            SymmetricAlgorithm symAlg = SymmetricAlgorithm.Create("3DES");
            symAlg.Key = srcKeyData;
            symAlg.IV = Keys;

            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(
                                                    mStream,
                                                    symAlg.CreateEncryptor(),
                                                    CryptoStreamMode.Write);


            cStream.Write(srcData, 0, srcData.Length);
            cStream.FlushFinalBlock();
            cStream.Clear();
            return mStream.ToArray();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="srcData">源数据</param>
        /// <param name="strKey">密钥</param>
        /// <returns>解密后的字节数组,若解密失败则返回null</returns>
        public byte[] Decrypt(byte[] srcData, string strKey)
        {
            if (null == srcData || srcData.Length < 1) return null;

            //将密钥散列
            byte[] srcKeyData = HashDigest.StringDigest(strKey, DigestType.MD5);
            SymmetricAlgorithm symAlg = SymmetricAlgorithm.Create("3DES");
            symAlg.Key = srcKeyData;
            symAlg.IV = Keys;

            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(
                                                    mStream,
                                                    symAlg.CreateDecryptor(),
                                                    CryptoStreamMode.Write);


            cStream.Write(srcData, 0, srcData.Length);
            cStream.FlushFinalBlock();
            cStream.Clear();
            return mStream.ToArray();
        }

        /// <summary>
        /// 3DES加密字符串
        /// </summary>
        /// <param name="srcString">待加密的字符串</param>
        /// <param name="strKey">用于加密的密钥</param>
        /// <returns>加密完成后的结果</returns>
        public string EncryptString(string srcString, string strKey)
        {
            byte[] bytEncrypted = Encrypt(Encoding.Default.GetBytes(srcString), strKey);
            return ByteStringUtil.ByteArrayToHexStr(bytEncrypted);
        }

        /// <summary>
        /// 3DES解密字符串
        /// </summary>
        /// <param name="srcString">待解密的字符串(此参数的值应当是调用EncryptString所得的结果)</param>
        /// <param name="strKey">用于加密的密钥</param>
        /// <returns>解密完成后的结果</returns>
        public string DecryptString(string srcString, string strKey)
        {
            byte[] byt = ByteStringUtil.ByteArrayFromHexStr(srcString);
            return Encoding.Default.GetString(Decrypt(byt, strKey));
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="srcStr"></param>
        /// <returns></returns>
        public string EncryptString(string srcStr)
        {
            return EncryptString(srcStr, this.DefaultKey);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="srcStr"></param>
        /// <returns></returns>
        public string DecryptString(string srcStr)
        {
            return DecryptString(srcStr, this.DefaultKey);
        }
    }
}
