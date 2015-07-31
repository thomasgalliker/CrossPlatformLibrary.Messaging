using System;

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

        public SmsTask()
        {
        }

        #region ISmsTask Members

        public bool CanSendSms
        {
            get
            {
                return MFMessageComposeViewController.CanSendText;
            }
        }

        public void SendSms(string recipient, string message)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentNullException("recipient");
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }

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
                            throw new ArgumentException("sender");
                        }

                        uiViewController.DismissViewController(true, () => { });
                    };

                this.smsController.Finished += handler;

                this.smsController.PresentUsingRootViewController();
            }
        }

        #endregion
    }
}