using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.Web.Core.Common;

namespace Ultra.Surface.Common {
    public sealed class Util {
        private static string ConKey = "9641A10F3A492082A172E64683454EF3";
        private static string PwdKey = "A492082A172E646808234549641A10EF";

        public static string Encrypt(string src) {
            DESEncrypt d = new DESEncrypt();
            return d.EncryptString(src, ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(ConKey)));
        }

        public static string Decrypt(string src) {
            DESEncrypt d = new DESEncrypt();
            return d.DecryptString(src, ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(ConKey)));
        }

        public static string EncryptPwd(string src) {
            DESEncrypt d = new DESEncrypt();
            return ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(
                d.EncryptString(src, ByteStringUtil.ByteArrayToHexStr(
                HashDigest.StringDigest(PwdKey)))));
        }
    }
}
