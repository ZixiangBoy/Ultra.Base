using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ultra.Web.Core.Common
{
    [Serializable]
    public class UltraMailSender
    {
        public void SendMail(string title, string body, params string[] attachFile)
        {
            MailAddress address = new MailAddress(this.SenderEMail, this.SenderName);
            MailMessage message = new MailMessage {
                Subject = title,
                From = address
            };
            message.To.Add(new MailAddress(this.RecverMailAddr, this.RecverMailAddr));
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = this.IsBodyHtml;
            message.Priority = MailPriority.High;
            if ((attachFile != null) && (attachFile.Length > 0))
            {
                foreach (string str in attachFile)
                {
                    if (System.IO.File.Exists(str))
                    {
                        message.Attachments.Add(new Attachment(str));
                    }
                }
            }
            SmtpClient client = new SmtpClient {
                Host = this.SmtpSvr,
                UseDefaultCredentials = false
            };
            int index = this.SenderEMail.IndexOf("@");
            client.Credentials = new NetworkCredential(this.SenderEMail.Left(index, null), this.SenderPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(message);
        }

        public bool IsBodyHtml { get; set; }

        public string RecverMailAddr { get; set; }

        public string SenderEMail { get; set; }

        public string SenderName { get; set; }

        public string SenderPwd { get; set; }

        public string SmtpSvr { get; set; }
    }
}

