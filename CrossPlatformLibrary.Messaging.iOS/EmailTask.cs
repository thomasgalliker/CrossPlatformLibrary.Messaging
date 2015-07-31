using System;

#if __UNIFIED__
using Foundation;
using MessageUI;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.MessageUI;
using MonoTouch.UIKit;
#endif


namespace CrossPlatformLibrary.Messaging
{
    public class EmailTask : IEmailTask
    {
        private MFMailComposeViewController mailController;

        public bool CanSendEmail
        {
            get
            {
                return MFMailComposeViewController.CanSendMail;
            }
        }

        public void SendEmail(EmailMessage email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (this.CanSendEmail)
            {
                this.mailController = new MFMailComposeViewController();
                this.mailController.SetSubject(email.Subject);
                this.mailController.SetMessageBody(email.Message, email.IsHtml);
                this.mailController.SetToRecipients(email.Recipients.ToArray());

                if (email.RecipientsCc.Count > 0)
                {
                    this.mailController.SetCcRecipients(email.RecipientsCc.ToArray());
                }

                if (email.RecipientsBcc.Count > 0)
                {
                    this.mailController.SetBccRecipients(email.RecipientsBcc.ToArray());
                }

                foreach (var attachment in email.Attachments)
                {
                    this.mailController.AddAttachmentData(NSData.FromStream(attachment.Content), attachment.ContentType, attachment.FileName);
                }

                EventHandler<MFComposeResultEventArgs> handler = null;
                handler = (sender, e) =>
                    {
                        this.mailController.Finished -= handler;

                        var uiViewController = sender as UIViewController;
                        if (uiViewController == null)
                        {
                            throw new ArgumentException("sender");
                        }

                        uiViewController.DismissViewController(true, () => { });
                    };

                this.mailController.Finished += handler;

                this.mailController.PresentUsingRootViewController();
            }
        }

        public void SendEmail(string to, string subject, string message)
        {
            this.SendEmail(new EmailMessage(to, subject, message));
        }
    }
}