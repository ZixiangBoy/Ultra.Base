using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Ultra.Web.Core.Class
{
    public class SendMail
    {
        private MailMessage mailMessage = new MailMessage();
        private string password;
        private SmtpClient smtpClient;

        public SendMail(string To, string From, string Body, string Title, string Password)
        {
            this.mailMessage.To.Add(To);
            this.mailMessage.From = new MailAddress(From);
            this.mailMessage.Subject = Title;
            this.mailMessage.Body = Body;
            this.mailMessage.IsBodyHtml = true;
            this.mailMessage.BodyEncoding = Encoding.UTF8;
            this.mailMessage.Priority = MailPriority.Normal;
            this.password = Password;
        }

        public void Attachments(string Path)
        {
            string[] strArray = Path.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                Attachment item = new Attachment(strArray[i], "application/octet-stream");
                ContentDisposition contentDisposition = item.ContentDisposition;
                contentDisposition.CreationDate = System.IO.File.GetCreationTime(strArray[i]);
                contentDisposition.ModificationDate = System.IO.File.GetLastWriteTime(strArray[i]);
                contentDisposition.ReadDate = System.IO.File.GetLastAccessTime(strArray[i]);
                this.mailMessage.Attachments.Add(item);
            }
        }

        public void Send(string smtpusr, string smtpsvr)
        {
            if (this.mailMessage != null)
            {
                this.smtpClient = new SmtpClient();
                this.smtpClient.Credentials = new NetworkCredential(smtpusr, this.password);
                this.smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                this.smtpClient.Host = smtpsvr;
                this.smtpClient.Send(this.mailMessage);
            }
        }

        public void SendAsync(SendCompletedEventHandler CompletedMethod)
        {
            if (this.mailMessage != null)
            {
                this.smtpClient = new SmtpClient();
                this.smtpClient.Credentials = new NetworkCredential(this.mailMessage.From.Address, this.password);
                this.smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                this.smtpClient.Host = "smtp." + this.mailMessage.From.Host;
                this.smtpClient.SendCompleted += new SendCompletedEventHandler(CompletedMethod.Invoke);
                this.smtpClient.SendAsync(this.mailMessage, this.mailMessage.Body);
            }
        }
    }
}

