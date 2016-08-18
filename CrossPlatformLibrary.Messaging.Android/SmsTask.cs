
using Android.Content;

using Guards;

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
            Guard.ArgumentNotNull(recipient, nameof(recipient));
            Guard.ArgumentNotNull(message, nameof(message));

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