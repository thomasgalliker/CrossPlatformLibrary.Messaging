using System;
using System.Linq;
using Windows.ApplicationModel.Email;
using Windows.Storage.Streams;

using Guards;

namespace CrossPlatformLibrary.Messaging
{
    public class EmailTask : IEmailTask
    {
        public EmailTask()
        {
        }

        public bool CanSendEmail
        {
            get { return true; }
        }

        public bool CanSendEmailAttachments
        {
            get { return true; }
        }

        public bool CanSendEmailBodyAsHtml
        {
            get { return false; }
        }

        public void SendEmail(IEmailMessage email)
        {
            Guard.ArgumentNotNull(email, nameof(email));

            if (this.CanSendEmail)
            {
                var mail = new Windows.ApplicationModel.Email.EmailMessage
                {
                    Subject = email.Subject,
                    Body = email.Message
                };

                foreach (var recipient in email.Recipients)
                {
                    mail.To.Add(new EmailRecipient(recipient));
                }
                foreach (var recipient in email.RecipientsCc)
                {
                    mail.CC.Add(new EmailRecipient(recipient));
                }
                foreach (var recipient in email.RecipientsBcc)
                {
                    mail.Bcc.Add(new EmailRecipient(recipient));
                }

                foreach (var attachment in email.Attachments.Cast<EmailAttachment>())
                {
                    RandomAccessStreamReference streamRef = RandomAccessStreamReference.CreateFromFile(attachment.File);
                    mail.Attachments.Add(new Windows.ApplicationModel.Email.EmailAttachment(attachment.FileName, streamRef));
                }

#pragma warning disable 4014
                EmailManager.ShowComposeNewEmailAsync(mail);
#pragma warning restore 4014
            }
        }

        public void SendEmail(string to, string subject, string message)
        {
            this.SendEmail(new EmailMessage(to, subject, message));
        }
    }
}
