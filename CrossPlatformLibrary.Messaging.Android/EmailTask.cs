using System;

using Android.Content;
using Android.Text;

using Guards;

using Uri = Android.Net.Uri;

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
            // NOTE: http://developer.xamarin.com/recipes/android/networking/email/send_an_email/

            Guard.ArgumentNotNull(email, nameof(email));

            if (email.Attachments.Count > 1)
            {
                throw new NotSupportedException("Cannot send more than once attachment for Android");
            }

            if (this.CanSendEmail)
            {
                Intent emailIntent = new Intent(Intent.ActionSend);
                emailIntent.SetType("message/rfc822");

                if (email.Recipients.Count > 0)
                {
                    emailIntent.PutExtra(Intent.ExtraEmail, email.Recipients.ToArray());
                }

                if (email.RecipientsCc.Count > 0)
                {
                    emailIntent.PutExtra(Intent.ExtraCc, email.RecipientsCc.ToArray());
                }

                if (email.RecipientsBcc.Count > 0)
                {
                    emailIntent.PutExtra(Intent.ExtraBcc, email.RecipientsBcc.ToArray());
                }

                emailIntent.PutExtra(Intent.ExtraSubject, email.Subject);

                // NOTE: http://stackoverflow.com/questions/13756200/send-html-email-with-gmail-4-2-1

                if (((EmailMessage)email).IsHtml)
                {
                    emailIntent.PutExtra(Intent.ExtraText, Html.FromHtml(email.Message));
                }
                else
                {
                    emailIntent.PutExtra(Intent.ExtraText, email.Message);
                }

                if (email.Attachments.Count > 0)
                {
                    EmailAttachment attachment = email.Attachments[0];
                    var uri = Uri.Parse("file://" + attachment.FileName);

                    emailIntent.PutExtra(Intent.ExtraStream, uri);
                }

                emailIntent.StartNewActivity();
            }
        }

        public void SendEmail(string to, string subject, string message)
        {
            this.SendEmail(new EmailMessage(to, subject, message));
        }
    }
}