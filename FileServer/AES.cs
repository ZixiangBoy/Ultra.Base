using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileServer
{
    class AES
    {
        //默认密钥向量   
        private static byte[] _key1 = { 0x95, 0x93, 0x56, 0x78, 0x78, 0xA3, 0x0D, 0xCF, 0xDB, 0x38, 0x58, 0x78, 0x91, 0xAE, 0xBE, 0xFF };
        private static string PwdKey = "9C338A78B25C1C4580331ED70DE378895F12F90DB3DEA8BBC838D8DF55BE5A385694584D7ACBB2E3";
        /// <summary>  
        /// AES加密算法  
        /// </summary>  
        /// <param name="plainText">明文字符串</param>  
        /// <param name="strKey">密钥</param>  
        /// <returns>返回加密后的密文字节数组</returns>  
        protected static byte[] AESEncrypt(string plainText, string strKey)
        {
            //分组加密算法  
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);//得到需要加密的字节数组      
            //设置密钥及密钥向量  
            des.Key = Encoding.UTF8.GetBytes(strKey);
            des.IV = _key1;
            using (MemoryStream ms = new MemoryStream())
            {
                using (
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    byte[] cipherBytes = ms.ToArray();//得到加密后的字节数组  
                    cs.Close();
                    ms.Close();
                    return cipherBytes;
                }
            }
        }

        /// <summary>  
        /// AES解密  
        /// </summary>  
        /// <param name="cipherText">密文字节数组</param>  
        /// <param name="strKey">密钥</param>  
        /// <returns>返回解密后的字符串</returns>  
        protected static byte[] AESDecrypt(byte[] cipherText, string strKey)
        {
            SymmetricAlgorithm des = Rijndael.Create();
            des.Key = Encoding.UTF8.GetBytes(strKey);
            des.IV = _key1;
            byte[] decryptBytes = new byte[cipherText.Length];
            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(decryptBytes, 0, decryptBytes.Length);
                    cs.Close();
                    ms.Close();
                    return decryptBytes;
                }
            }
        }

        public static string Encrypt(string str)
        {
            var kb = Ultra.Web.Core.Common.HashDigest.StringDigest(PwdKey);
            //分组加密算法  
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);//得到需要加密的字节数组      
            //设置密钥及密钥向量  
            des.Key = kb;
            des.IV = _key1;
            using (MemoryStream ms = new MemoryStream())
            {
                using (
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    byte[] cipherBytes = ms.ToArray();//得到加密后的字节数组  
                    cs.Close();
                    ms.Close();
                    return Ultra.Web.Core.Common.ByteStringUtil.ByteArrayToHexStr(cipherBytes);
                }
            }
        }

        public static string Decrypt(string str)
        {
            SymmetricAlgorithm des = Rijndael.Create();
            var kb = Ultra.Web.Core.Common.HashDigest.StringDigest(PwdKey);
            des.Key = kb;
            des.IV = _key1;
            var cipherText = Ultra.Web.Core.Common.ByteStringUtil.ByteArrayFromHexStr(str);
            byte[] decryptBytes = new byte[cipherText.Length];
            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(decryptBytes, 0, decryptBytes.Length);
                    cs.Close();
                    ms.Close();
                    return Encoding.UTF8.GetString(decryptBytes);
                }
            }
        }
    }

    public static class Extensions
    {
        //public static string GetClientIP(this HttpRequestMessage request)
        //{
        //    return ((System.Web.HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
        //}


        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage =
            "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";
        public static string GetClientIpAddress(this System.Net.Http.HttpRequestMessage request)
        {
            // Web-hosting. Needs reference to System.Web.dll
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }

            // Self-hosting. Needs reference to System.ServiceModel.dll. 
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            // Self-hosting using Owin. Needs reference to Microsoft.Owin.dll. 
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic owinContext = request.Properties[OwinContext];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }

            return string.Empty;
        }

        public static Dictionary<string, string> ToDictionary(this string keyValue)
        {
            return keyValue.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(part => part.Split('='))
                          .ToDictionary(split => split[0], split => split[1]);
        }
    }
}
