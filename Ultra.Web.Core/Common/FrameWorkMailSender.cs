using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;


namespace Ultra.Web.Core.Common
{
    /// <summary>
    /// 邮件发送帮助类
    /// </summary>
    [Serializable]
    public class UltraMailSender
    {
        /// <summary>
        /// 发件人邮箱地址
        /// </summary>
        public string SenderEMail { get; set; }

        /// <summary>
        /// 发件人显示名称
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 发件人邮箱登录密码
        /// </summary>
        public string SenderPwd { get; set; }

        /// <summary>
        /// smtp服务器地址
        /// </summary>
        public string SmtpSvr { get; set; }

        /// <summary>
        /// 收件箱地址
        /// </summary>
        public string RecverMailAddr { get; set; }

        /// <summary>
        /// 是否HTML邮件
        /// </summary>
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="title">主题</param>
        /// <param name="body">内容</param>
        /// <param name="attachFile">附件</param>
        public void SendMail(string title, string body, params string[] attachFile)
        {
            MailAddress from = new MailAddress(SenderEMail, SenderName); //邮件的发件人
            MailMessage mail = new MailMessage();
            //设置邮件的标题
            mail.Subject = title;
            mail.From = from;
            mail.To.Add(new MailAddress(RecverMailAddr, RecverMailAddr));
            //设置邮件的内容
            mail.Body = body;
            //设置邮件的格式
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = IsBodyHtml;
            //设置邮件的发送级别
            mail.Priority = MailPriority.High;
            //if (!string.IsNullOrEmpty(attachFile) && File.Exists(attachFile))
            if (null != attachFile && attachFile.Length > 0)
            {
                foreach (var fi in attachFile)
                {
                    if(File.Exists(fi))
                        mail.Attachments.Add(new Attachment(fi));
                }
            }

            SmtpClient client = new SmtpClient();
            //设置用于 SMTP 事务的主机的名称，填IP地址也可以了
            client.Host = SmtpSvr;
            //设置用于 SMTP 事务的端口，默认的是 25
            //client.Port = 25;
            client.UseDefaultCredentials = false;
            var idx = SenderEMail.IndexOf("@");

            //这里才是真正的邮箱登陆名和密码，比如我的邮箱地址是 hbgx@hotmail， 我的用户名为 hbgx ，我的密码是 xgbh
            client.Credentials = new System.Net.NetworkCredential(SenderEMail.Left(idx), SenderPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
        }
    }
}
