
using Android.Content;
using Android.Telephony;

using Guards;

using Uri = Android.Net.Uri;

namespace CrossPlatformLibrary.Messaging
{
    public class PhoneCallTask : IPhoneCallTask
    {
        public bool CanMakePhoneCall
        {
            get
            {
                return true;
            }
        }

        public void MakePhoneCall(string number, string name = null)
        {
            Guard.ArgumentNotNull(number, nameof(number));

            if (this.CanMakePhoneCall)
            {
                var phoneNumber = PhoneNumberUtils.FormatNumber(number);

                Uri telUri = Uri.Parse("tel:" + phoneNumber);
                var dialIntent = new Intent(Intent.ActionDial, telUri);

                dialIntent.StartNewActivity();
            }
        }
    }
}