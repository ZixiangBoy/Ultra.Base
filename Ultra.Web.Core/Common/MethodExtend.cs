using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Ultra.Web.Core.Interface;
using Ultra.Web.Core.Class;
using System.Text.RegularExpressions;
using Microsoft.International.Converters.PinYinConverter;

namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// 扩展方法集
    /// </summary>
    public static class MethodExtend
    {
        #region String 相关

        /// <summary>
        /// 过滤替换字符串中的SQL关键字字符串如:([,]*%...)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strFilter">需要被过滤的字符串内容</param>
        /// <returns>过滤完成后的结果</returns>
        public static string SqlKeyCharFilter(this string str, string strFilter)
        {
            if (string.IsNullOrEmpty(strFilter)) return strFilter;
            return FilterStringReplace(strFilter);
        }

        /// <summary>
        /// 返回字符串是否包含  HTML标签 &lt;Img src=..../>
        /// </summary>
        /// <param name="htmlstr"></param>
        /// <returns></returns>
        public static bool IsHtmlContainImg(this string htmlstr)
        {
            var rgx = new Regex(@"(<img.*?src=(.*?)>){1,}");
            var mch = rgx.Match(htmlstr);
            return mch.Success;
        }

        /// <summary>
        /// 特殊查询字符串过滤
        /// </summary>
        /// <param name="src">查询字符串</param>
        /// <returns></returns>
        private static string FilterStringReplace(string src)
        {
            return src.Replace("[", "[[ ")
                .Replace("]", " ]]")
                .Replace("*", "[*]")
                .Replace("%", "[%]")
                .Replace("[[ ", "[[]")
                .Replace(" ]]", "[]]")
                .Replace("\"", "\"\"");
        }


        /// <summary>
        /// 返回字符串左起 length 个字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSrc">截取该字符串左起 length个字符</param>
        /// <param name="length">返回的字符数</param>
        /// <returns></returns>
        public static string Left(this string str, string strSrc, int length)
        {
            if (string.IsNullOrEmpty(strSrc)) return strSrc;
            if (strSrc.Length <= length) return strSrc;
            return strSrc.Substring(0, length);
        }

        /// <summary>
        /// 返回字符串左起 length 个字符
        /// </summary>
        /// <param name="src"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string Left(this string src, int length)
        {
            if (string.IsNullOrEmpty(src)) return src;
            if (src.Length <= length) return src;
            return src.Substring(0, length);
        }

        /// <summary>
        /// 返回字符串左起 length 个字符
        /// 如果字符串原始长度比length小或相等则返回原始字符串
        /// 否则返回字符串左起 length 个字符并在末尾连接上apend中指定的字符
        /// </summary>
        /// <param name="src">从中进行截取的字符串</param>
        /// <param name="length">截取的长度</param>
        /// <param name="apend">要在末尾连接上的字符内容</param>
        /// <returns>返回字符串左起 length 个字符</returns>
        public static string Left(this string src, int length, string apend = null)
        {
            if (string.IsNullOrEmpty(apend)) return Left(src, length);
            if (src.Length > apend.Length)
            {
                return string.Format("{0}{1}", Left(src, length, apend));
            }
            else
                return src;
        }

        /// <summary>
        /// 忽略字符串大小写的比较
        /// </summary>
        /// <param name="src">被比较的字符串</param>
        /// <param name="cmp">被比较的字符串</param>
        /// <returns>如果忽略大小写的比较相等则返回true否则为false</returns>
        public static bool EqualIgnorCase(this string src, string cmp)
        {
            return string.Compare(src, cmp, true) == 0;
        }

        /// <summary>
        /// 将字符串转换为字节数组
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string src)
        {
            return ToBytes(src, Encoding.Default);
        }

        /// <summary>
        /// 将字符串以指定的编码格式转换为字节数组
        /// </summary>
        /// <param name="src"></param>
        /// <param name="coding"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string src, Encoding coding)
        {
            src = string.IsNullOrEmpty(src) ? string.Empty : src;
            return coding.GetBytes(src);
        }

        /// <summary>
        /// 转换编码显示的字符串
        /// </summary>
        /// <param name="src"></param>
        /// <param name="coding"></param>
        /// <returns></returns>
        public static string ToEncodeStr(this string src, Encoding coding)
        {
            if (string.IsNullOrEmpty(src)) return src;
            var bts = src.ToBytes(coding);
            return coding.GetString(bts);
        }

        /// <summary>
        /// 转换 为 Base64编码输出
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ToBase64(this string src)
        {
            byte[] bytes_1 = System.Text.Encoding.Default.GetBytes(src);
            return Convert.ToBase64String(bytes_1);
        }

        /// <summary>
        /// 将Base64编码的数据转换为编码前的数据
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string FromBase64(this string src)
        {
            byte[] bytes_2 = Convert.FromBase64String(src);
            return System.Text.Encoding.Default.GetString(bytes_2);
        }

        /// <summary>
        /// 将以十六进制表示的字符串转换为对应的字节数组
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] HexStrToBytes(this string src)
        {
            if (string.IsNullOrEmpty(src)) return null;
            return ByteStringUtil.ByteArrayFromHexStr(src);
        }

        /// <summary>
        /// 字符串若为连接字符串,则尝试使用此连接串连接到目标数据库
        /// 如果无法连接成功则返回false
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool CanConnToDBServer(this string src)
        {
            if (string.IsNullOrEmpty(src)) return false;
            try
            {
                using (SqlConnection conn = new SqlConnection(src))
                {
                    conn.Open();
                    bool bok = conn.State == ConnectionState.Open;
                    if (bok) conn.Close();
                    return bok;
                }
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// 读取指定路径的文件的首行,如果文件不存在,则返回string.Empty
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="enc">文件编码方式</param>
        /// <returns></returns>
        public static string ReadFirstLine(this string filePath, Encoding enc)
        {
            if (string.IsNullOrEmpty(filePath)) return string.Empty;
            if (!File.Exists(filePath)) return string.Empty;
            using (StreamReader sr = new StreamReader(filePath, enc))
            {
                return sr.ReadLine();
            }
        }

        /// <summary>
        /// 尝试打开文件,如果文件被占用则打开失败返回false,否则返回true
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CanOpen(this string filePath)
        {
            try
            {
                File.OpenWrite(filePath).Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断指定的字符串表示的文件是否存在
        /// </summary>
        /// <param name="filePath">字符串表示的文件</param>
        /// <returns>存在返回true</returns>
        public static bool FileExists(this string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;
            return File.Exists(filePath);
        }

        /// <summary>
        /// 转换string为对应的目标类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">内容</param>
        /// <returns></returns>
        public static T ChangeType<T>(this string str)
        {
            return (T)(Convert.ChangeType(str, typeof(T)));
        }

        /// <summary>
        /// 尝试打开文件,如果文件被占用则打开失败返回false,否则返回true
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        public static bool CanOpen(this string filePath, out string errmsg)
        {
            try
            {
                errmsg = string.Empty;
                File.OpenWrite(filePath).Close();
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取指定路径的文件的首行,如果文件不存在,则返回string.Empty
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFirstLine(this string filePath)
        {
            return ReadFirstLine(filePath, Encoding.Default);
        }

        /// <summary>
        /// HttpUtility.UrlEncode(url)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlEncode(this string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        /// <summary>
        /// HttpUtility.UrlEncode(url,enc)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="enc"></param>
        /// <returns></returns>
        public static string UrlEncode(this string url, Encoding enc)
        {
            return HttpUtility.UrlEncode(url, enc);
        }

        /// <summary>
        /// HttpUtility.UrlDecode(url,enc)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="enc"></param>
        /// <returns></returns>
        public static string UrlDecode(this string url, Encoding enc)
        {
            return HttpUtility.UrlDecode(url, enc);
        }

        /// <summary>
        /// HttpUtility.UrlDecode(url)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlDecode(this string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        /// <summary>
        /// HttpUtility.HtmlEncode(str);
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// HttpUtility.HtmlDecode(str)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlDecode(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// 返回哈希字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Hash(this string str)
        {
            return
            ByteStringUtil.ByteArrayToHexStr(
            HashDigest.StringDigest(str));
        }

        /// <summary>
        /// 返回文件哈希值(MD5)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FileHash(this string path)
        {
            return
            ByteStringUtil.ByteArrayToHexStr(
            HashDigest.FileDigest(path, DigestType.MD5));
        }

        /// <summary>
        /// 将指定的串例如：access_token=822b4b46290dcb8f0aa2de75d2d4d36c&expires_in=604800解析为QueryString
        /// 迭代方式：foreach(var item in returnvalue.AllKeys)
        /// </summary>
        /// <param name="querystr">欲解析的串</param>
        /// <returns></returns>
        public static System.Collections.Specialized.NameValueCollection AsQueryString(this string querystr)
        {
            var hr = new HttpRequest(string.Empty, "http://www.g.cn", querystr);
            return hr.QueryString;
        }

        /// <summary>
        /// 比較兩字符串(忽略大小寫)是否相等
        /// </summary>
        /// <param name="str">用於比較的字符串</param>
        /// <param name="str2">用於比較的字符串</param>
        /// <returns>字符串相等則返回true,否則為false</returns>
        public static bool IgnoreCaseEqual(this string str, string str2)
        {
            return string.Compare(str, str2, true) == 0;
        }

        /// <summary>
        /// 将字符串所表示的路径指向的程序集文件加载为内存程序集
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Assembly LoadAsMemAsm(this string str)
        {
            return ObjectHelper.LoadAsm(str);
        }

        /// <summary>
        /// 获取字符串所表示的路径指向的程序集文件程序集内继承自指定类的所有子类列表
        /// </summary>
        /// <param name="str">字符串所表示的路径指向的程序集文件</param>
        /// <param name="tbase">指定的基类</param>
        /// <returns>所有子类列表</returns>
        public static List<Type> GetAllClassOfClass(this string str, Type tbase)
        {
            return ObjectHelper.GetAllClassOfClass(tbase, LoadAsMemAsm(str));
        }

        /// <summary>
        /// 从源字符串str中得到  strStart 与 strEnd之间 的内容
        /// 无法匹配成功则返回string.Empty
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="strStart">起始串</param>
        /// <param name="strEnd">结束串</param>
        /// <returns>从源字符串str中得到  strStart 与 strEnd之间 的内容</returns>
        public static string GetBetween(this string str, string strStart, string strEnd)
        {
            if (string.IsNullOrEmpty(str)) return str;
            var idx = str.IndexOf(strStart);
            if (idx < 0) return string.Empty;
            var idxend = str.IndexOf(strEnd);
            if (idxend < 0) return string.Empty;
            var kk = idxend - (idx + strStart.Length);
            if (kk < 1) return string.Empty;
            return str.Substring(idx + strStart.Length, kk);
        }

        /// <summary>
        /// 替换源字符串str中  strStart 与 strEnd之间 的内容
        /// 为 rep中指定的内容
        /// 无法匹配成功则返回string.Empty
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="strStart">起始串</param>
        /// <param name="strEnd">结束串</param>
        /// <param name="rep">替换为的内容</param>
        /// <returns>替换后的结果</returns>
        public static string ReplaceBetween(this string str, string strStart, string strEnd, string rep = "")
        {
            if (string.IsNullOrEmpty(str)) return str;
            var idx = str.IndexOf(strStart);
            if (idx < 0) return string.Empty;
            var idxend = str.IndexOf(strEnd);
            if (idxend < 0) return string.Empty;
            var kk = idxend - (idx + strStart.Length);
            if (kk < 1) return string.Empty;
            return str.Left(idx + strStart.Length) + rep + str.Substring(idxend, str.Length - idxend);
        }

        /// <summary>
        /// 将srcImgPath指定处的图片转化为指定宽高的缩略图
        /// 会对参数中的路径做Server.MapPath
        /// </summary>
        /// <param name="srcImgPath"></param>
        /// <param name="width">缩略的宽</param>
        /// <param name="height">缩略的高</param>
        /// <returns>转换后的图片对象</returns>
        public static System.Drawing.Image Thumnail(this string srcImgPath, int width, int height)
        {
            var img = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(srcImgPath));
            var ig = img.Thumnail(width, height);
            img.Dispose();
            return ig;
        }

        private static Regex RgxIP = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

        /// <summary>
        /// 验证一给定的字符串是否是IP地址表示形式
        /// </summary>
        /// <param name="str"></param>
        /// <returns>如果是IP地址表示形式则返回true,否则为false</returns>
        public static bool IsIPAddress(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            return RgxIP.IsMatch(str);
        }

        private static Regex RgxAllChineseChar = new Regex(@"([\u4e00-\u9fa5]*)?");

        /// <summary>
        /// 判断指定的字符串是不是全部是汉字
        /// </summary>
        /// <param name="str">欲判断的字符串</param>
        /// <returns>若为全包含汉字则返回true,否则为false</returns>
        public static bool IsAllChineseChar(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            var mc = RgxAllChineseChar.Match(str);
            if (null == mc || mc.Groups.Count < 2) return false;
            for (int i = 1; i < mc.Groups.Count; i++)
            {
                if (mc.Groups[i].Length < 1) return false;
            }
            return true;
        }

        /// <summary>    
        /// 汉字转化为拼音   
        /// </summary>    
        /// <param name="str">汉字</param>    
        /// <returns>全拼</returns>    
        public static string GetPinyin(this string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length - 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }

        /// <summary>    
        /// 汉字转化为拼音首字母   
        /// </summary>    
        /// <param name="str">汉字</param>    
        /// <returns>首字母</returns>    
        public static string GetShortPinyin(this string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }   

        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToInt(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            int dt;
            if (!int.TryParse(str, out dt)) return null;
            return dt;
        }

        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultvalue"></param>
        /// <returns></returns>
        public static int ToInt(this string str, int defaultvalue)
        {
            int? i = ToInt(str);
            return i == null ? defaultvalue : i.Value;
        }

        /// <summary>
        /// 验证手机号有效性
        /// 有效返回true否则为false
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        public static bool ValidMobileNumber(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum)) return false;
            var match = System.Text.RegularExpressions.Regex.Match(phoneNum, @"\d{11,12}");
            return (match != null && match.Success && match.Value == phoneNum);
        }

        /// <summary>
        /// 判断是否为有效的手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobileNum(this string str)
        {
            return ValidMobileNumber(str);
        }

        /// <summary>
        /// 转换为long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long? ToLong(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            long dt;
            if (!long.TryParse(str, out dt)) return null;
            return dt;
        }

        /// <summary>
        /// 转换为long
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultvalue">如果转换不成功需要被返回的默认值</param>
        /// <returns></returns>
        public static long? ToLong(this string str, long defaultvalue)
        {
            if (string.IsNullOrEmpty(str)) return defaultvalue;
            long dt;
            if (!long.TryParse(str, out dt)) return defaultvalue;
            return dt;
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            decimal dt;
            if (!decimal.TryParse(str, out dt)) return null;
            return dt;
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultvalue"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string str, decimal defaultvalue)
        {
            decimal? d = ToDecimal(str);
            return d == null ? defaultvalue : d.Value;
        }

        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="lng"></param>
        /// <returns></returns>
        public static int ToInt(this long lng) { return (int)lng; }

        /// <summary>
        /// 生成Guid.NewGuid().ToString()去掉连接符后的文字内容
        /// </summary>
        /// <param name="str"></param>
        /// <returns>生成Guid.NewGuid().ToString()去掉连接符后的文字内容</returns>
        public static string GetGuidStr(this string str)
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        /// <summary>
        /// 解析命行令参数
        /// </summary>
        /// <param name="cmdArgs">命行令参数</param>
        /// <returns>KEY:命令行参数名称.如:/cfg VALUE:命令行参数值.如:C:\windows</returns>
        public static Dictionary<string, string> ParseCmdArgs(this string[] cmdArgs)
        {
            if (null == cmdArgs || cmdArgs.Length < 1) return null;
            Dictionary<string, string> dic = new Dictionary<string, string>(cmdArgs.Length);
            Regex rgx = new Regex(@"(.+?):(.+)");
            foreach (var item in cmdArgs)
            {
                var cmdags = rgx.Split(item);
                if (null == cmdags || cmdags.Length < 3) continue;
                if (!dic.ContainsKey(cmdags[1]))
                    dic.Add(cmdags[1], cmdags[2]);
            }
            return dic;
        }

        /// <summary>
        /// 解析路径信息
        /// </summary>
        /// <param name="filePath">文件路径信息</param>
        /// <returns></returns>
        public static PathInfo GetPathInfo(this string filePath)
        {
            PathInfo pi = new PathInfo();
            pi.Directory = Path.GetDirectoryName(filePath);
            pi.FileName = Path.GetFileName(filePath);
            pi.FileExtenName = Path.GetExtension(filePath);
            pi.FileWithOutExt = Path.GetFileNameWithoutExtension(filePath);
            pi.Drive = Directory.GetDirectoryRoot(filePath);
            return pi;
        }

        /// <summary>
        /// 对图片文件生成缩略图
        /// </summary>
        /// <param name="sourcefile">原始图片文件</param>
        /// <param name="destinationfile">生成的缩略图文件</param>
        /// <param name="width">缩略的宽度</param>
        /// <param name="height">缩略的高度</param>
        public static void GenerateThumbNail(this string sourcefile, string destinationfile, int width,int height)
        {
            System.Drawing.Image image =
               System.Drawing.Image.FromFile(sourcefile);
            int srcWidth = image.Width;
            int srcHeight = image.Height;
            int thumbWidth = width;
            int thumbHeight;
            System.Drawing.Bitmap bmp;
            if (srcHeight > srcWidth)
            {
                thumbHeight = height;// (srcHeight / srcWidth) * thumbWidth;
                bmp = new System.Drawing.Bitmap(thumbWidth, thumbHeight);
            }
            else
            {
                thumbHeight = height;// thumbWidth;
                thumbWidth = width;// (srcWidth / srcHeight) * thumbHeight;
                bmp = new System.Drawing.Bitmap(thumbWidth, thumbHeight);
            }

            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            System.Drawing.Rectangle rectDestination =
                   new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
            gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, System.Drawing.GraphicsUnit.Pixel);
            bmp.Save(destinationfile);
            bmp.Dispose();
            image.Dispose();
        }

        /// <summary>
        /// 对图片文件生成缩略图
        /// </summary>
        /// <param name="sourcefile">原始图片文件</param>
        /// <param name="destinationfile">生成的缩略图文件</param>
        /// <param name="width">缩略的宽度</param>
        /// <param name="height">缩略的高度</param>
        public static void ThumbnailImage(this string sourcefile, string destinationfile, int width, int height)
        {
            sourcefile.GenerateThumbNail(destinationfile, width, height);
        }

        /// <summary>
        /// 图片合成
        /// </summary>
        /// <param name="srcFile">源图文件路径</param>
        /// <param name="combinFile">需要被合成到源图中的文件路径</param>
        /// <param name="destFile">合成后的图片输出路径</param>
        /// <param name="pt">combinFile要合成到srcFile中的起始位置坐标</param>
        /// <param name="encmb">当值为EnImageCombinOrd.Reverse则将会把combinFile画到srcFile图像的背后 否则 为前面.默认值为EnImageCombinOrd.Reverse</param>
        /// <param name="buseadjust">默认为true.内容会开启合成后的图片质量微调</param>
        public static void CombinImage(this string srcFile, string combinFile, string destFile, System.Drawing.Point pt,EnImageCombinOrd encmb= EnImageCombinOrd.Reverse,bool buseadjust=true)
        {
            System.Drawing.Image image =System.Drawing.Image.FromFile(srcFile);
            int srcWidth = image.Width;
            int srcHeight = image.Height;

            System.Drawing.Image imgcmb =System.Drawing.Image.FromFile(combinFile);

            if (encmb == EnImageCombinOrd.Normal)
            {
                using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(image))
                {
                    if (buseadjust)
                    {
                        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//HighQuality;
                        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;// High;
                    }

                    //gr.DrawImage(imgcmb, rectDestination, 0, 0, srcWidth, srcHeight, System.Drawing.GraphicsUnit.Pixel);
                    gr.DrawImage(imgcmb, pt);
                    image.Save(destFile);
                    imgcmb.Dispose();
                    image.Dispose();
                }
            }
            else if (encmb == EnImageCombinOrd.Reverse)
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(srcWidth, srcHeight);
                using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp))
                {
                    if (buseadjust)
                    {
                        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//HighQuality;
                        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;// High;
                    }
                    gr.DrawImage(imgcmb, pt);
                    gr.DrawImage(image, 0, 0);
                    bmp.Save(destFile);
                    imgcmb.Dispose();
                    image.Dispose();
                }
            }
        }

        /// <summary>
        /// 返回图片文件的宽高.如果图片不存在返回 宽:0,高:0
        /// </summary>
        /// <param name="srcFile">图片文件路径</param>
        /// <returns>返回图片文件的宽高.如果图片不存在返回 宽:0,高:0</returns>
        public static System.Drawing.Size ImageSize(this string srcFile)
        {
            if (string.IsNullOrEmpty(srcFile)||!File.Exists(srcFile)) return new System.Drawing.Size(0,0);
            using (var img = System.Drawing.Image.FromFile(srcFile))
            {
                return new System.Drawing.Size(img.Width, img.Height);
            }
        }

        /// <summary>
        /// 计算字符串表达式结果
        /// </summary>
        /// <param name="exp">运算表达式.例如:3*5+8/2-1</param>
        /// <returns>表达式计算完成后的结果</returns>
        public static string Calc(this string exp)
        {
            return UltraDynamic.Default.Calc(exp);
        }

        /// <summary>
        /// 根据文件后缀名获取文件的媒体类型。
        /// </summary>
        /// <param name="fileName">带后缀的文件名或文件全名</param>
        /// <returns>媒体类型</returns>
        private static string GetMimeTypeString(string fileName)
        {
            string mimeType;
            fileName = fileName.ToLower();

            if (fileName.EndsWith(".bmp", StringComparison.CurrentCulture))
            {
                mimeType = "image/bmp";
            }
            else if (fileName.EndsWith(".gif", StringComparison.CurrentCulture))
            {
                mimeType = "image/gif";
            }
            else if (fileName.EndsWith(".jpg", StringComparison.CurrentCulture) || fileName.EndsWith(".jpeg", StringComparison.CurrentCulture))
            {
                mimeType = "image/jpeg";
            }
            else if (fileName.EndsWith(".png", StringComparison.CurrentCulture))
            {
                mimeType = "image/png";
            }
            else
            {
                mimeType = "application/octet-stream";
            }

            return mimeType;
        }

        /// <summary>
        /// 根据文件后缀名获取文件的媒体类型。
        /// </summary>
        /// <param name="filename">带后缀的文件名或文件全名</param>
        /// <returns>媒体类型.返回值例如:image/bmp,image/png,...application/octet-stream</returns>
        public static string GetMimeType(this string filename)
        {
            return GetMimeTypeString(filename);
        }


        /// <summary>
        /// 获取文件的真实后缀名。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>JPG, GIF, PNG or null</returns>
        private static string GetFileSuffix(byte[] fileData)
        {
            if (fileData == null || fileData.Length < 10)
            {
                return null;
            }

            if (fileData[0] == 'G' && fileData[1] == 'I' && fileData[2] == 'F')
            {
                return "GIF";
            }
            else if (fileData[1] == 'P' && fileData[2] == 'N' && fileData[3] == 'G')
            {
                return "PNG";
            }
            else if (fileData[6] == 'J' && fileData[7] == 'F' && fileData[8] == 'I' && fileData[9] == 'F')
            {
                return "JPG";
            }
            else if (fileData[0] == 'B' && fileData[1] == 'M')
            {
                return "BMP";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取文件的真实后缀名。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>JPG, GIF, PNG or null</returns>
        public static string GetFileExtName(this byte[] fileData)
        {
            return GetFileSuffix(fileData);
        }

        /// <summary>
        /// 获取文件的真实媒体类型。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>媒体类型</returns>
        private static string GetMimeTypeString(byte[] fileData)
        {
            string suffix = GetFileSuffix(fileData);
            string mimeType;

            switch (suffix)
            {
                case "JPG": mimeType = "image/jpeg"; break;
                case "GIF": mimeType = "image/gif"; break;
                case "PNG": mimeType = "image/png"; break;
                case "BMP": mimeType = "image/bmp"; break;
                default: mimeType = "application/octet-stream"; break;
            }

            return mimeType;
        }

        /// <summary>
        /// 获取文件的真实媒体类型。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>媒体类型</returns>
        public static string GetMimeType(this byte[] fileData)
        {
            return GetMimeTypeString(fileData);
        }

        /// <summary>
        /// 将指定的连接字符串转换为支持异步数据查询的连接串
        /// </summary>
        /// <param name="connstr">原始连接字符串</param>
        /// <returns>支持异步数据查询的连接串</returns>
        public static string GetAsyncConnString(this string connstr)
        {
            SqlConnectionStringBuilder connBuild = new SqlConnectionStringBuilder(connstr);
            connBuild.AsynchronousProcessing = true;
            return connBuild.ConnectionString;
        }

        #endregion

        #region DataTable 相关


        /// <summary>
        /// 将DataTable的列名称进行 Trim 截取 并返回截取操作完成后的所有列的列名称集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<string> TrimColumnName(this DataTable dt)
        {
            if (null == dt || dt.Columns == null || dt.Columns.Count < 1) return null;
            List<string> dcs = new List<string>(dt.Columns.Count);
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ColumnName = dc.ColumnName.Trim();
                dcs.Add(dc.ColumnName);
            }
            return dcs;
        }

        /// <summary>
        /// 将DataTable数据写入到由参数tbName指定的表中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="connstr">连接串</param>
        /// <param name="tbName">写入到的目标表名</param>
        /// <param name="tbFields">需要写入的DataTable中的列的名称集合</param>
        public static void WriteToServer(this DataTable dt, string connstr, string tbName,
            params string[] tbFields)
        {
            if (string.IsNullOrEmpty(tbName) || string.IsNullOrEmpty(connstr)
                || null == dt || dt.Rows.Count < 1 || dt.Columns == null || dt.Columns.Count < 1) return;
            using (SqlBulkCopy blk = new SqlBulkCopy(connstr))
            {
                blk.DestinationTableName = tbName;
                if (null != tbFields && tbFields.Length > 0)
                {
                    foreach (var item in tbFields)
                        blk.ColumnMappings.Add(item, item);
                }
                else
                {
                    foreach (DataColumn dc in dt.Columns)
                        blk.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                }
                blk.WriteToServer(dt);
            }
        }

        /// <summary>
        /// 将数据表对象转化为特定的对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToEntity<T>(this DataTable dt) where T : new()
        {
            if (null == dt || dt.Rows.Count < 1) return null;
            return ObjectHelper.Create<T>(dt);
        }

        #endregion

        #region DateTime 相关

        /// <summary>
        /// 获取对应日期的农历
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string GetChinaDate(this DateTime d)
        {
            return ChineseDate.GetDate(d);
        }

        /// <summary>
        /// 返回 当前日期对象减去 d2 在指定日期部分的差值
        /// </summary>
        /// <param name="d"></param>
        /// <param name="enDatePrt"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static int DateDiff(this DateTime d, EnDatePart enDatePrt, DateTime d2)
        {
            return DateDiff(enDatePrt, d2, d);
        }


        /// <summary>
        /// 获取两个日期(de2-de1)
        /// 之间指定日期部分的差值
        /// 与Diff函数的区别在于会考虑 年月日部分的差异
        /// </summary>
        /// <param name="enDatePrt">日期部分</param>
        /// <param name="de1">开始日期</param>
        /// <param name="de2">结束日期</param>
        /// <returns>两个日期(de2-de1)之间指定日期部分的差值</returns>
        public static int DateDiff(EnDatePart enDatePrt, DateTime de1, DateTime de2)
        {
            TimeSpan tms1 = new TimeSpan(de1.Ticks);
            TimeSpan tms2 = new TimeSpan(de2.Ticks);
            TimeSpan tms3 = tms2.Subtract(tms1);
            switch (enDatePrt)
            {
                case EnDatePart.NONE:
                    return 0;
                case EnDatePart.DAY:
                    return (int)(tms3.TotalDays);
                case EnDatePart.HOUR:
                    return (int)(tms3.TotalHours);
                case EnDatePart.MINUTE:
                    return (int)(tms3.TotalMinutes);
                case EnDatePart.SECOND:
                    return (int)(tms3.TotalSeconds);
                default:
                    return 0;
            }
        }


        /// <summary>
        /// 将日期的年月日部分同步为 de2指定的年月日部分
        /// </summary>
        /// <param name="deOri"></param>
        /// <param name="de2"></param>
        /// <returns></returns>
        public static DateTime SyncYearMonthDay(this DateTime deOri, DateTime de2)
        {
            return UpdateYearMonthDay(deOri, de2);
        }


        /// <summary>
        /// 更新日期的年月日部分为参数 de 的年月日
        /// </summary>
        /// <param name="deOri"></param>
        /// <param name="de"></param>
        /// <returns></returns>
        public static DateTime UpdateYearMonthDay(DateTime deOri, DateTime de)
        {
            DateTime deRtn = deOri;
            deRtn = DateTime.Parse(string.Format("{0}-{1}-{2} {3}:{4}:{5}", de.Year,
                de.Month, de.Day, deRtn.Hour, deRtn.Minute, deRtn.Second));
            return deRtn;
        }

        /// <summary>
        /// 转换为 yyyy-MM-dd HH:mm:ss 格式的日期字符串
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        public static string ToDefaultStr(this DateTime? de)
        {
            if (null == de) return string.Empty;
            return de.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        /// 转换为 yyyy-MM-dd HH:mm:ss 格式的日期字符串
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        public static string ToDefaultStr(this DateTime de)
        {
            return de.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 比较两个日期区间范围的时分秒部分是否一致
        /// </summary>
        /// <param name="deOri"></param>
        /// <param name="de2"></param>
        /// <returns></returns>
        public static bool IsTimePartEqual(this DateTime deOri, DateTime de2)
        {
            return deOri.Hour == de2.Hour && deOri.Minute == de2.Minute && deOri.Second == de2.Second;
        }

        /// <summary>
        /// 比较两个日期区间范围的年月日部分是否一致
        /// </summary>
        /// <param name="deOri"></param>
        /// <param name="de2"></param>
        /// <returns></returns>
        public static bool IsDatePartEqual(this DateTime deOri, DateTime de2)
        {
            return deOri.Year == de2.Year && deOri.Month == de2.Month && deOri.Day == de2.Month;
        }

        /// <summary>
        /// 将两个日期区间范围按指定的天数拆分
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static List<DateTime> Split(this DateTime begin, DateTime end, int days)
        {
            if (days <= 0) days = 1;
            DateTime ed = begin;
            end = end.Swap(ref ed);
            begin = ed;
            List<DateTime> lst = new List<DateTime>();
            if (end.DateDiff(EnDatePart.DAY, begin) > days)
            {
                lst.Add(begin);
                while (end.CompareTo(begin = begin.AddDays(days)) > 0)
                    lst.Add(begin);
                lst.Add(end);
            }
            else
                return new List<DateTime> { begin, end };
            return lst;
        }

        /// <summary>
        /// 将指定日期以指定的天数进行拆分
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static List<DateTimeRange> SplitDateRange(this DateTime begin, DateTime end, int days)
        {
            List<DateTime> lst = begin.Split(end, days);
            if (lst == null || lst.Count < 1) return null;
            if (lst.Count == 2)
                return new List<DateTimeRange> { new DateTimeRange { Begin = lst[0], End = lst[1] } };
            Stack<DateTime> stk = new Stack<DateTime>(2);
            DateTime prv; List<DateTimeRange> lstRng = new List<DateTimeRange>(lst.Count);
            foreach (DateTime d in lst)
            {
                stk.Push(d);
                if (stk.Count > 1)
                {
                    DateTimeRange rng = new DateTimeRange();
                    rng.End = prv = stk.Pop();
                    rng.Begin = stk.Pop();
                    stk.Clear();
                    stk.Push(prv);
                    lstRng.Add(rng);
                }
            }
            return lstRng;
        }

        /// <summary>
        /// 比较两个日期返回日期较大的一个,在输出 参数中返回日期较小的一个
        /// </summary>
        /// <param name="deOri"></param>
        /// <param name="deCmp"></param>
        /// <returns></returns>
        public static DateTime Swap(this DateTime deOri, ref DateTime deCmp)
        {
            DateTime deMax = deOri.CompareTo(deCmp) > 0 ? deOri : deCmp;
            DateTime deMin = deOri.CompareTo(deCmp) < 0 ? deOri : deCmp;
            deCmp = deMin;
            return deMax;
        }

        #endregion

        #region IList 相关


        /// <summary>
        /// 根据当前列表对象数据映射成对应的DataTable结构
        /// </summary>
        /// <typeparam name="T">列表元素对象类型</typeparam>
        /// <param name="lstT">列表数据</param>
        /// <param name="propertyArgs">需要映射的类型T的属性字段名称</param>
        /// <returns></returns>
        public static DataTable GetDataTable<T>(this IList<T> lstT, params string[] propertyArgs)
        {
            if (null == lstT) return null;
            DataTable dt = ObjectDataMaper<T>.DataTableSechma(propertyArgs);
            foreach (T item in lstT)
            {
                if (null == item) continue;
                DataRow dr = dt.NewRow();
                var ptys = typeof(T).GetProperties();
                propertyArgs = propertyArgs != null && propertyArgs.Length > 0
                    ? propertyArgs
                    : ptys.Select(im => im.Name).ToArray();
                foreach (var pty in propertyArgs)
                {
                    var ps = ptys.Where(arg => arg.Name == pty).ToList();
                    if (null == ps || ps.Count < 1)
                    {
                        throw new Exception("找不到包含: " + pty + " 的属性");
                    }
                    var p = ps.First();
                    if (null == p) continue;
                    Type coltyp = p.PropertyType;
                    //可空类型
                    //if (coltyp.IsGenericType && coltyp.GetGenericTypeDefinition() == typeof(Nullable<>))
                    //{
                    //    coltyp = coltyp.GetGenericArguments()[0];
                    //}
                    object objvlu = p.GetValue(item, null);
                    dr[pty] = null == p ? DBNull.Value : ((null == objvlu) ? DBNull.Value : objvlu);
                    //Convert.ChangeType(p.GetValue(item, null), coltyp);
                    //p.GetValue(item, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 根据当前列表对象数据映射成对应的DataTable结构
        /// </summary>
        /// <typeparam name="T">列表元素对象类型</typeparam>
        /// <param name="lstT">列表数据</param>
        /// <param name="propOrFields">需要映射的类型T的属性字段及字段名称</param>
        /// <returns></returns>
        public static DataTable GetDataTableEx<T>(this IList<T> lstT, string[] propOrFields)
        {
            if (null == lstT) return null;
            List<PropertyInfo> propList; List<FieldInfo> fieldList;
            DataTable dt = ObjectDataMaper<T>.DataTableSechmaEx(propOrFields, out propList, out fieldList);
            foreach (T item in lstT)
            {
                if (null == item) continue;
                DataRow dr = dt.NewRow();
                if (null != propList && propList.Count > 0)//存在属性
                {
                    foreach (var p in propList)
                    {
                        object objvlu = p.GetValue(item, null);
                        dr[p.Name] = null == p ? DBNull.Value : ((null == objvlu) ? DBNull.Value : objvlu);
                    }
                }
                if (null != fieldList && fieldList.Count > 0)//存在字段
                {
                    foreach (var f in fieldList)
                    {
                        object objvlu = f.GetValue(item);
                        dr[f.Name] = null == f ? DBNull.Value : ((null == objvlu) ? DBNull.Value : objvlu);
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        #region SqlBulkCopy 相关


        /// <summary>
        /// 将lstT中的数据批量写入至目标数据表中
        /// </summary>
        /// <typeparam name="T">列表元素对象类型</typeparam>
        /// <param name="blk">SqlBulkCopy对象</param>
        /// <param name="lstT">列表数据</param>
        /// <param name="propertyArgs">需要映射的类型T的属性字段名称</param>
        public static void WriteToServer<T>(this SqlBulkCopy blk, IList<T> lstT, params string[] propertyArgs)
        {
            if (null == lstT || lstT.Count < 1) return;
            DataTable dt = lstT.GetDataTable<T>(propertyArgs);
            if (null == dt || dt.Rows.Count < 1) return;
            blk.ColumnMappings.Clear();
            foreach (DataColumn item in dt.Columns)
            {
                blk.ColumnMappings.Add(item.ColumnName, item.ColumnName);
            }
            blk.WriteToServer(dt);
        }

        public static void WriteToServer<T>(this SqlBulkCopy blk, T ent, params string[] propertyArgs)
        {
            WriteToServer<T>(blk, new List<T> { ent }, propertyArgs);
        }

        /// <summary>
        /// 将lstT中的数据批量写入至目标数据表中
        /// </summary>
        /// <typeparam name="T">列表元素对象类型</typeparam>
        /// <param name="blk">SqlBulkCopy对象</param>
        /// <param name="lstT">列表数据</param>
        /// <param name="fnc">传递列表数据转换得到的DataTable,回调函数可以在此回调内移除指定列以达到不回写特定字段至目标库</param>
        public static void WriteToServer<T>(this SqlBulkCopy blk, IList<T> lstT, Func<DataTable, DataTable> fnc = null)
        {
            if (null == lstT || lstT.Count < 1) return;
            DataTable dt = lstT.GetDataTable<T>();
            if (null == dt || dt.Rows.Count < 1) return;
            blk.ColumnMappings.Clear();
            if (null != fnc)
                dt = fnc(dt);
            foreach (DataColumn item in dt.Columns)
            {
                blk.ColumnMappings.Add(item.ColumnName, item.ColumnName);
            }
            blk.WriteToServer(dt);
        }

        /// <summary>
        /// 将lstT中的数据批量写入至目标数据表中
        /// </summary>
        /// <typeparam name="T">列表元素对象类型</typeparam>
        /// <param name="blk">SqlBulkCopy对象</param>
        /// <param name="lstT">列表数据</param>
        /// <param name="fnc">传递列表数据转换得到的DataTable,回调函数可以在此回调内移除指定列以达到不回写特定字段至目标库</param>
        public static void WriteToServerAdv<T>(this SqlBulkCopy blk, IList<T> lstT, Func<DataTable, DataTable> fnc = null)
        {
            if (null == lstT || lstT.Count < 1) return;
            DataTable dt = lstT.GetDataTable<T>();
            if (null == dt || dt.Rows.Count < 1) return;
            blk.ColumnMappings.Clear();
            if (null != fnc)
                dt = fnc(dt);
            foreach (DataColumn item in dt.Columns)
            {
                blk.ColumnMappings.Add(item.ColumnName, item.ColumnName);
            }
            blk.WriteToServer(dt);
        }

        /// <summary>
        /// 将lstT中的数据批量写入至目标数据表中
        /// 不会将 IBaseEntity 中定义的属性类型写入到表中
        /// </summary>
        /// <typeparam name="T">列表元素对象类型</typeparam>
        /// <param name="blk">SqlBulkCopy对象</param>
        /// <param name="lstT">列表数据</param>
        public static void WriteToServer<T>(this SqlBulkCopy blk, IList<T> lstT)
        {
            var pts = typeof(IBaseEntity).GetProperties();
            var pis = pts.Select(i => i.Name).ToList();
            if (!pis.Contains("Timestamp"))
                pis.Add("Timestamp");
            WriteToServer(blk, lstT, (t1) =>
            {
                pis.ForEach(i =>
                {
                    if (t1.Columns.Contains(i))
                        t1.Columns.Remove(i);
                });
                return t1;
            });
        }

        /// <summary>
        /// 将lstT中的数据批量写入至目标数据表中
        /// 不会将 IBaseEntity 中定义的属性类型写入到表中
        /// </summary>
        /// <typeparam name="T">列表元素对象类型</typeparam>
        /// <param name="blk">SqlBulkCopy对象</param>
        /// <param name="lstT">列表数据</param>
        /// <param name="excludes">不想被写入的属性列表</param>
        public static void WriteToServerAdv<T>(this SqlBulkCopy blk, IList<T> lstT,string[] excludes)
        {
            //var pts = typeof(IBaseEntity).GetProperties();
            var pis = new List<string>(15); //pts.Select(i => i.Name).ToList();
            //if (!pis.Contains("Timestamp"))
                pis.Add("Timestamp");
            if (null != excludes && excludes.Length > 0)
                pis.AddRange(excludes);
            WriteToServer(blk, lstT, (t1) =>
            {
                pis.ForEach(i =>
                {
                    if (t1.Columns.Contains(i))
                        t1.Columns.Remove(i);
                });
                return t1;
            });
        }

        public static void WriteToServerEx<T>(this SqlBulkCopy blk, IList<T> lstT, string[] propOrField)
        {
            if (null == lstT || lstT.Count < 1) return;
            DataTable dt = lstT.GetDataTableEx<T>(propOrField);
            if (null == dt || dt.Rows.Count < 1) return;
            blk.ColumnMappings.Clear();
            foreach (DataColumn item in dt.Columns)
            {
                blk.ColumnMappings.Add(item.ColumnName, item.ColumnName);
            }
            blk.WriteToServer(dt);
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="blk"></param>
        /// <param name="lstT"></param>
        /// <param name="fieldMap"></param>
        /// <param name="defaultVluSet">回调处理方法,可在此方法内通过增加默认值列</param>
        public static void WriteToServerEx<T>(this SqlBulkCopy blk, IList<T> lstT, IEnumerable<PropertyMap> fieldMap,
            Func<DataTable, DataTable> defaultVluSet = null)
        {

            if (null == lstT || lstT.Count < 1 || null == fieldMap || fieldMap.Count() < 1) return;
            DataTable dt = lstT.GetDataTableEx<T>(fieldMap.Select(i => i.PropOrFieldName).ToArray());
            var dic = fieldMap.ToDictionary(i => i.PropOrFieldName);
            foreach (DataColumn dc in dt.Columns)
            {
                if (dic.ContainsKey(dc.ColumnName))
                    dc.ColumnName = dic[dc.ColumnName].TableFieldName;
            }
            if (null != defaultVluSet)
                dt = defaultVluSet(dt);
            blk.ColumnMappings.Clear();
            foreach (DataColumn item in dt.Columns)
            {
                blk.ColumnMappings.Add(item.ColumnName, item.ColumnName);
            }
            blk.WriteToServer(dt);
        }

        #endregion

        #region Cookie 相关

        /// <summary>
        /// 获取Cookie中存储的序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cke"></param>
        /// <returns></returns>
        public static T GetObject<T>(this HttpCookie cke)
        {
            if (null == cke) return default(T);
            UltraCookie<T> uck = new UltraCookie<T>();
            var et = uck.DeSeriesObject<T>(cke.Value);
            uck = null;
            return et;
        }

        #endregion

        #region Page 相关

        /// <summary>
        /// 获取 客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP(this System.Web.UI.Page pg)
        {
            return pg.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// 请求的URL的主机部分：例如 http://www.google.co.uk/image/pic.aspx 将返回 www.google.co.uk
        /// 如果是 http://localhost:8099/..../x.aspx 将返回 localhost:8099
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static string GetHost(this System.Web.HttpRequest req)
        {
            return req.Url.Authority;
        }

        /// <summary>
        /// 请求的URL的主机部分：例如 http://www.google.co.uk/image/pic.aspx 将返回 www.google.co.uk
        /// </summary>
        /// <param name="pg"></param>
        /// <returns></returns>
        public static string GetHost(this System.Web.UI.Page pg)
        {
            return pg.Request.GetHost();
        }

        /// <summary>
        /// 返回请求的url （会包含?id=xxx&v=xxxx.....)
        /// </summary>
        /// <param name="pg"></param>
        /// <returns>返回请求的url （会包含?id=xxx&v=xxxx.....)</returns>
        public static string RawUrl(this System.Web.UI.Page pg)
        {
            return pg.RequestUrl();
        }

        /// <summary>
        /// 返回请求的url （会包含?id=xxx&v=xxxx.....)
        /// </summary>
        /// <param name="pg"></param>
        /// <returns>返回请求的url （会包含?id=xxx&v=xxxx.....)</returns>
        public static string RequestUrl(this System.Web.UI.Page pg)
        {
            return pg.Request.RawUrl;
        }

        /// <summary>
        /// Response.Redirect(url)的包装
        /// </summary>
        /// <param name="pg"></param>
        /// <param name="url">要重定位到的目标URL</param>
        public static void Redirect(this System.Web.UI.Page pg,string url)
        {
            pg.Response.Redirect(url);
        }

        /// <summary>
        /// 文件全路径转换为服务器相对路径
        /// </summary>
        /// <param name="pg"></param>
        /// <param name="fileFullPath">文件全路径</param>
        /// <returns>服务器相对路径</returns>
        public static string FilePathToMapPath(this System.Web.UI.Page pg, string fileFullPath)
        {
            string tmpRootDir = pg.Server.MapPath(pg.Request.ApplicationPath);//获取程序根目录
            string imagesurl2 = fileFullPath.Replace(tmpRootDir, string.Empty); //转换成相对路径
            return imagesurl2;
        }

        #endregion

        #region Assmbly 相关

        /// <summary>
        /// 获取继承指定接口的所有类型
        /// 若接口类型名称为空则获取所有类型
        /// </summary>
        /// <param name="asm"></param>
        /// <param name="interfaceName">接口类型名称默认为空</param>
        /// <returns>获取继承指定接口的所有类型</returns>
        public static List<Type> GetAllClassOfInterface(this Assembly asm, string interfaceName = "")
        {
            return ObjectHelper.GetAllClassOfInterface(asm, interfaceName);
        }

        /// <summary>
        /// 获取程序集内继承自指定类的所有子类列表
        /// </summary>
        /// <param name="asm"></param>
        /// <param name="tbase">指定的基类</param>
        /// <returns>所有子类列表</returns>
        public static List<Type> GetAllClassOfClass(this Assembly asm, Type tbase)
        {
            return ObjectHelper.GetAllClassOfClass(tbase, asm);
        }

        #endregion

        #region PropertyInfo 相关

        /// <summary>
        /// 获取属性的描述
        /// </summary>
        /// <param name="pi">属性</param>
        /// <returns>属性的描述</returns>
        public static string GetPropertyDesc(this PropertyInfo pi)
        {
            return ObjectHelper.GetPropertyDesc(pi);
        }

        /// <summary>
        /// 判断属性类型是否为可空
        /// </summary>
        /// <param name="pi">属性</param>
        /// <returns>不是可空则返回true否则为false</returns>
        public static bool IsRequired(this PropertyInfo pi)
        {
            return ObjectHelper.IsRequired(pi);
        }

        #endregion

        #region FieldInfo 相关

        /// <summary>
        /// 获取字段描述
        /// </summary>
        /// <param name="fi">字段</param>
        /// <returns>字段描述</returns>
        public static string GetFieldDesc(this FieldInfo fi)
        {
            if (null == fi) return string.Empty;
            var atr = fi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
            if (null == atr || atr.Count() < 1) return string.Empty;
            var a = atr.First() as System.ComponentModel.DescriptionAttribute;
            if (null == a) return string.Empty;
            return a.Description;
        }

        /// <summary>
        /// 判断字段类型是否为可空
        /// </summary>
        /// <param name="fi">字段</param>
        /// <returns>不是可空则返回true否则为false</returns>
        public static bool IsRequired(this FieldInfo fi)
        {
            return ObjectHelper.IsRequired(fi);
        }

        #endregion

        #region bool 相关

        /// <summary>
        /// 生成并发布尔值实例,支持并发访问
        /// </summary>
        /// <param name="b">初始值</param>
        /// <returns></returns>
        public static InterlockBoolean GetLockBool(this bool b)
        {
            return InterlockBoolean.Create(b);
        }

        /// <summary>
        /// 返回随机布尔值
        /// </summary>
        /// <param name="b"></param>
        /// <returns>返回随机布尔值</returns>
        public static bool RandomBool(this bool b)
        {
            var k = 10;
            return k.Random().IsEven();
        }

        #endregion

        #region Image 相关

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="img"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static System.Drawing.Image Thumnail(this System.Drawing.Image img, int width, int height)
        {
            return GenLiteImage(img, width, height);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static System.Drawing.Image Thumnail(this System.Drawing.Image img)
        {
            return Thumnail(img, 97, 45);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="byt"></param>
        /// <param name="width"></param>
        /// <param name="heigth"></param>
        /// <returns></returns>
        public static System.Drawing.Image ToThumnailImage(this byte[] byt, int width, int heigth)
        {
            return GenLiteImage(byt, width, heigth);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="byt"></param>
        /// <returns></returns>
        public static System.Drawing.Image ToThumnailImage(this byte[] byt)
        {
            return GenLiteImage(byt, 97, 45);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="imgData"></param>
        /// <returns></returns>
        public static System.Drawing.Image GenLiteImage(byte[] imgData, int width, int height)
        {
            using (MemoryStream ms = new MemoryStream(imgData))
            {
                //生成缩略图
                var tempImg = System.Drawing.Image.FromStream(ms);
                var newImg = new System.Drawing.Bitmap(tempImg, width, height);
                using (MemoryStream ms2 = new MemoryStream())
                {
                    newImg.Save(ms2, tempImg.RawFormat);
                    var newImgData = new byte[ms2.Length];
                    ms2.Position = 0;
                    ms2.Read(newImgData, 0, newImgData.Length);
                    return System.Drawing.Image.FromStream(ms2);
                }
            }
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="img"></param>
        /// <param name="width"></param>
        /// <param name="heigth"></param>
        /// <returns></returns>
        public static System.Drawing.Image GenLiteImage(System.Drawing.Image img, int width, int height)
        {
            var newImg = new System.Drawing.Bitmap(img, width, height);
            using (MemoryStream ms2 = new MemoryStream())
            {
                newImg.Save(ms2, img.RawFormat);
                var newImgData = new byte[ms2.Length];
                ms2.Position = 0;
                ms2.Read(newImgData, 0, newImgData.Length);
                return System.Drawing.Image.FromStream(ms2);
            }
        }

        /// <summary>
        /// 复制Image(防止文件占用锁,或是同一对象占用)
        /// </summary>
        /// <param name="img"></param>
        /// <returns>复制后的Image</returns>
        public static System.Drawing.Image CopyImage(this System.Drawing.Image img)
        {
            var newImg = new System.Drawing.Bitmap(img, img.Width, img.Height);
            using (MemoryStream ms2 = new MemoryStream())
            {
                newImg.Save(ms2, img.RawFormat);
                var newImgData = new byte[ms2.Length];
                ms2.Position = 0;
                ms2.Read(newImgData, 0, newImgData.Length);
                return System.Drawing.Image.FromStream(ms2);
            }
        }

        /// <summary>
        /// 将Image转换为字节流
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this System.Drawing.Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        #endregion

        #region FileUpload 相关

        /// <summary>
        /// 保存上传文件
        /// 同时生成缩略图(当bGenLite=true时)
        /// </summary>
        /// <param name="fup">文件上传控件</param>
        /// <param name="thumbnailArg">仅当bGenLite为true时有意义,表示生成缩略图的相关参数</param>
        /// <param name="bGenLite">是否自动生成图片缩略图</param>
        public static void SaveImage(this System.Web.UI.WebControls.FileUpload fup,ref UploadImageThumnail thumbnailArg,bool bGenLite=false)
        {
            if (fup.HasFile)
            {
                fup.SaveAs(thumbnailArg.FileSaveAsPath);
                if (!bGenLite) return;//不生成缩略图
                
                    //1.判断是否提供了生成的缩略图的文件路径。如果提供了。则使用此路径。若没提供则使用与UploadImageThumnail.FileSaveAsPath
                    //同目录下并以 原始文件名_宽度_高度.png 形式生成缩略图文件,并将此路径写回参数
                    var thumPath = !string.IsNullOrEmpty(thumbnailArg.FileThumnailPath) ? thumbnailArg.FileThumnailPath : null;
                    if (string.IsNullOrEmpty(thumPath))
                    {
                        var pi = thumbnailArg.FileSaveAsPath.GetPathInfo();
                        thumPath = Path.Combine(pi.Directory, string.Format("{0}_{1}_{2}{3}", pi.FileWithOutExt,
                            thumbnailArg.ThumWidth, thumbnailArg.ThumHeight, pi.FileExtenName));
                    }
                    //生成缩略图
                    thumbnailArg.FileSaveAsPath.GenerateThumbNail(thumPath, thumbnailArg.ThumWidth, thumbnailArg.ThumHeight);
                    thumbnailArg.FileThumnailPath = thumPath;
            }
            return;
        }

        #endregion

        #region Guid 相关

        /// <summary>
        /// 生成Guid.NewGuid().ToString()去掉连接符后的文字内容
        /// </summary>
        /// <param name="gid"></param>
        /// <returns>生成Guid.NewGuid().ToString()去掉连接符后的文字内容</returns>
        public static string NewGuidStr(this Guid gid)
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        #endregion

        #region Int
                
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="maxValue">随机数的最大值</param>
        /// <param name="rng">随机数生成器</param>
        /// <returns>生成随机数</returns>
        public static int Random(this int maxValue, System.Security.Cryptography.RNGCryptoServiceProvider rng=null)
        {
            rng = rng ?? new System.Security.Cryptography.RNGCryptoServiceProvider();
            decimal _base = (decimal)long.MaxValue;
            byte[] rndSeries = new byte[8];
            rng.GetBytes(rndSeries);
            return (int)(Math.Abs(BitConverter.ToInt64(rndSeries, 0)) / _base * maxValue);            
        }

        /// <summary>
        /// 判断数是不是一个偶数
        /// </summary>
        /// <param name="i">被判断的数</param>
        /// <returns>数为偶数则返回true否则为false</returns>
        public static bool IsEven(this int i)
        {
            return (i & 1) == 0;
        } 

        /// <summary>
        /// 由keySet 生成随机组合
        /// </summary>
        /// <param name="keySet">生成随机组合的源串(字典)</param>
        /// <param name="stringlength">随机字符串的长度</param>
        /// <returns></returns>
        public static string RandomString(this string keySet, int stringlength)
        {
            //if (keySet == null || keySet.Length < 8) keySet = "abcdefghijkmnpqrstuvwxyz23456789";
            if (string.IsNullOrEmpty(keySet)) keySet = "abcdefghijkmnpqrstuvwxyz23456789";
            System.Security.Cryptography.RNGCryptoServiceProvider rng =
                new System.Security.Cryptography.RNGCryptoServiceProvider();
            int keySetLength = keySet.Length > keySet.Length ? keySet.Length : stringlength;
            StringBuilder str = new StringBuilder(keySet.Length);
            for (int i = 0; i < stringlength; ++i)
            {
                str.Append(keySet[keySetLength.Random(rng)]);
            }
            return str.ToString();
        }

        #endregion

    }

    /// <summary>
    /// 文件上传控件
    /// 上传图片并自动缩略图结构定义
    /// NOTE:调用者负责初始化 FileSaveAsPath,ThumbWidth,ThumbHeight 的值
    /// </summary>
    public class UploadImageThumnail
    {
        /// <summary>
        /// 文件 被保存到服务器上的路径
        /// </summary>
        public string FileSaveAsPath;

        /// <summary>
        /// 文件生成的缩略图 被保存到服务器上的路径
        /// PS:默认生成的缩略图路径与FileSaveAsPath位于同一目录
        /// 但在文件名后跟上 _width_height
        /// EG:FileSaveAsPath= abc.png
        /// FileThumbnailPath =abc_200_200.png
        /// </summary>
        public string FileThumnailPath;

        /// <summary>
        /// 欲缩略到的图片宽度
        /// </summary>
        public int ThumWidth;

        /// <summary>
        /// 欲缩略到的图片高度
        /// </summary>
        public int ThumHeight;
    }

    /// <summary>
    /// 文件路径信息
    /// </summary>
    public class PathInfo
    {
        /// <summary>
        /// 目录所在盘符 例如:E:\ 
        /// </summary>
        public string Drive { get; internal set; }

        /// <summary>
        /// 目录路径
        /// </summary>
        public string Directory { get; internal set; }

        /// <summary>
        /// 带扩展名的文件名称（EG: xxx.png,xxx.exe,....)
        /// </summary>
        public string FileName { get; internal set; }

        /// <summary>
        /// 不带扩展名的文件名称
        /// </summary>
        public string FileWithOutExt { get; internal set; }

        /// <summary>
        /// 文件扩展名 例如：.bmp,.png,....
        /// </summary>
        public string FileExtenName { get; internal set; }
    }

    /// <summary>
    /// 日期比较部分枚举
    /// </summary>
    public enum EnDatePart
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE,

        /// <summary>
        /// Day
        /// </summary>
        DAY,

        /// <summary>
        /// Hour
        /// </summary>
        HOUR,

        /// <summary>
        /// Minute
        /// </summary>
        MINUTE,

        /// <summary>
        /// Second
        /// </summary>
        SECOND,
    }

    /// <summary>
    /// 图片叠加的方式枚举
    /// </summary>
    public enum EnImageCombinOrd
    {
        /// <summary>
        /// 正片叠底
        /// </summary>
        Normal=1,

        /// <summary>
        /// 反转叠加
        /// </summary>
        Reverse=2,
    }

    /// <summary>
    /// 表示日期范围（跨度）
    /// </summary>
    [Serializable]
    public class DateTimeRange
    {
        /// <summary>
        /// 日期区间开始
        /// </summary>
        public DateTime Begin { get; set; }

        /// <summary>
        /// 日期区间结束
        /// </summary>
        public DateTime End { get; set; }

        public int UserDef { get; set; }

        public bool UserMark { get; set; }

        public override string ToString()
        {
            return Begin.ToDefaultStr() + End.ToDefaultStr().ToLower();
        }
    }


    /// <summary>
    /// 实体属性/字段名与目标表名映射
    /// </summary>
    public class PropertyMap
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PropertyMap() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pfname"></param>
        public PropertyMap(string pfname)
        {
            TableFieldName = PropOrFieldName = pfname;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tbField"></param>
        /// <param name="pfName"></param>
        public PropertyMap(string tbField, string pfName)
        {
            TableFieldName = tbField;
            PropOrFieldName = pfName;
        }

        /// <summary>
        /// 目标表字段名
        /// </summary>
        public string TableFieldName { get; set; }

        /// <summary>
        /// 属性/字段名称
        /// </summary>
        public string PropOrFieldName { get; set; }
    }

    /// <summary>
    /// API MoveFileFlags常量
    /// </summary>
    [Flags]
    public enum MoveFileFlags
    {
        MOVEFILE_REPLACE_EXISTING = 0x00000001,
        MOVEFILE_COPY_ALLOWED = 0x00000002,
        MOVEFILE_DELAY_UNTIL_REBOOT = 0x00000004,
        MOVEFILE_WRITE_THROUGH = 0x00000008,
        MOVEFILE_CREATE_HARDLINK = 0x00000010,
        MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x00000020
    }

    public static class FileMoveEx
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName,
            MoveFileFlags dwFlags);
    }

    /// <summary>
    /// 同步并发布尔值包装类,用于在并发环境中使用布尔类型
    /// </summary>
    public class InterlockBoolean
    {
        internal long BooleanValue = 0;

        private InterlockBoolean() { }

        /// <summary>
        /// 生成并发布尔值实例
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static InterlockBoolean Create(bool b = false)
        {
            InterlockBoolean v = new InterlockBoolean();
            v.BooleanValue = !b ? 0 : 1;
            return v;
        }

        /// <summary>
        /// 设置布尔值
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        protected virtual bool Set(bool b)
        {
            return System.Threading.Interlocked.Exchange(ref BooleanValue, b ? 1 : 0) != 0;
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        public virtual bool Value
        {
            get
            {
                return System.Threading.Interlocked.Read(ref BooleanValue) != 0;
            }
            set
            {
                Set(value);
            }
        }
    }

    /// <summary>
    /// 文件夹搜索文件扩展类
    /// </summary>
    public static class DirecotyEx
    {
        /// <summary>
        /// 多条件搜索指定扩展名的文件集合
        /// *.dll,*.exe
        /// 返回符合条件的文件路径列表集合
        /// </summary>
        /// <param name="path">在哪个路径下搜索</param>
        /// <param name="schpartens">扩展名集合如: *.dll *.exe</param>
        /// <param name="schopt">SearchOption枚举</param>
        /// <returns></returns>
        public static List<string> EnumerateFiles(string path, string[] schpartens, SearchOption schopt)
        {
            if (null == schpartens || schpartens.Length < 1 || string.IsNullOrEmpty(path) || !Directory.Exists(path))
                return null;
            List<string> lst = new List<string>(100);
            foreach (var item in schpartens)
            {
                if (string.IsNullOrEmpty(item)) continue;
                var k = Directory.EnumerateFiles(path, item, schopt).ToList();
                if (null == k || k.Count < 1) continue;
                lst.AddRange(k);
            }
            return lst;
        }
    }
}
