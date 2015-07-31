using System;

using Android.Content;

using Uri = Android.Net.Uri;

namespace CrossPlatformLibrary.Messaging
{
    // NOTE: http://developer.xamarin.com/recipes/android/networking/sms/send_an_sms/

    internal class SmsTask : ISmsTask
    {
        public bool CanSendSms
        {
            get
            {
                return true;
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
                var smsUri = Uri.Parse("smsto:" + recipient);
                var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", message);

                smsIntent.StartNewActivity();
            }
        }
    }
}