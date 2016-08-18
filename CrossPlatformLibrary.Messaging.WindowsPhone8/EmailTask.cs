using System.Collections.Generic;

using Guards;

using Microsoft.Phone.Tasks;

namespace CrossPlatformLibrary.Messaging
{
    internal class EmailTask : IEmailTask
    {
        public bool CanSendEmail
        {
            get
            {
                return true;
            }
        }

        public void SendEmail(EmailMessage email)
        {
            Guard.ArgumentNotNull(email, nameof(email));

            if (this.CanSendEmail)
            {
                var emailComposeTask = new EmailComposeTask
                {
                    Subject = email.Subject,
                    Body = email.Message,
                    To = ToDelimitedAddress(email.Recipients),
                    Cc = ToDelimitedAddress(email.RecipientsCc),
                    Bcc = ToDelimitedAddress(email.RecipientsBcc)
                };
                emailComposeTask.Show();
            }
        }

        public void SendEmail(string to, string subject, string message)
        {
            this.SendEmail(new EmailMessage(to, subject, message));
        }

        private static string ToDelimitedAddress(ICollection<string> collection)
        {
            return collection.Count == 0 ? string.Empty : string.Join(";", collection);
        }
    }
}