using System;

using Guards;
#if __UNIFIED__
using MessageUI;
using UIKit;
#else
using MonoTouch.MessageUI;
using MonoTouch.UIKit;

#endif

namespace CrossPlatformLibrary.Messaging
{
    internal class SmsTask : ISmsTask
    {
        private MFMessageComposeViewController smsController;

        public bool CanSendSms
        {
            get
            {
                return MFMessageComposeViewController.CanSendText;
            }
        }

        public void SendSms(string recipient, string message)
        {
            Guard.ArgumentNotNullOrEmpty(recipient, nameof(recipient));
            Guard.ArgumentNotNullOrEmpty(message, nameof(message));
          
            if (this.CanSendSms)
            {
                this.smsController = new MFMessageComposeViewController();
                this.smsController.Recipients = new[] { recipient };
                this.smsController.Body = message;

                EventHandler<MFMessageComposeResultEventArgs> handler = null;
                handler = (sender, args) =>
                    {
                        this.smsController.Finished -= handler;

                        var uiViewController = sender as UIViewController;
                        if (uiViewController == null)
                        {
                            throw new ArgumentException(nameof(sender));
                        }

                        uiViewController.DismissViewController(true, () => { });
                    };

                this.smsController.Finished += handler;

                this.smsController.PresentUsingRootViewController();
            }
        }
    }
}