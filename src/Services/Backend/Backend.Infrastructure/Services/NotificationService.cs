using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;

namespace Backend.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public bool SendEmailNotification(EmailNotifictionModel notification)
        {
            var send = SendEmail(notification.To, notification.Subject, notification.Body, notification.Attachment, notification.AttachmentNames, notification.Cc, notification.Cco);
            return send;
        }

        private bool SendEmail(string to, string subject, string body, List<string> attachment, List<string> attachmentNames, string cc = "", string bcc = "")
        {
            try
            {
                var configurationEmail = new EmailConfigurationModel();
                var mail = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress(configurationEmail.EmailFrom)
                };
                mail.To.Add(to);

                if (!string.IsNullOrEmpty(cc))
                    mail.CC.Add(cc);

                if (!string.IsNullOrEmpty(bcc))
                    mail.Bcc.Add(bcc);

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = System.Net.Mail.MailPriority.Normal;

                #region Adjuntos

                if (attachment != null)
                {
                    for (int i = 0; i < attachment.Count; i++)
                    {
                        var f = Convert.FromBase64String(attachment.ElementAt(i));
                        var data = new Attachment(new MemoryStream(f), attachmentNames.ElementAt(i));
                        mail.Attachments.Add(data);
                    }
                }

                IList<string> Att = new List<string>();
                #endregion

                var smtp1 = new SmtpClient();
                var credential = new NetworkCredential
                {
                    UserName = configurationEmail.EmailUser,  // replace with valid value
                    Password = configurationEmail.EmailPass   // replace with valid value
                };
                smtp1.Credentials = credential;
                smtp1.Host = configurationEmail.EmailServer;
                smtp1.Port = configurationEmail.EmailPort;
                smtp1.EnableSsl = configurationEmail.EmailEnabledSsl;
                smtp1.UseDefaultCredentials = false;
                smtp1.Send(mail);

            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
    }
}
