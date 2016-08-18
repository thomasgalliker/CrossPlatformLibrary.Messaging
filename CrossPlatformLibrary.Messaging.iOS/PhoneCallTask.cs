
using Guards;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;

#endif

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
            Guard.ArgumentNotNullOrEmpty(number, nameof(number));

            if (this.CanMakePhoneCall)
            {
                var nsurl = new NSUrl("tel://" + number);
                UIApplication.SharedApplication.OpenUrl(nsurl);
            }
        }
    }
}