
using System;

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
        public PhoneCallTask()
        {
        }

        #region IPhoneCallTask Members

        public bool CanMakePhoneCall
        {
            get
            {
                return true;
            }
        }

        public void MakePhoneCall(string number, string name = null)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException("number");
            }

            if (this.CanMakePhoneCall)
            {
                var nsurl = new NSUrl("tel://" + number);
                UIApplication.SharedApplication.OpenUrl(nsurl);
            }
        }

        #endregion
    }
}