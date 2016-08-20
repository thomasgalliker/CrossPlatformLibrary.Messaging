using System;
using Windows.ApplicationModel.Calls;

using Guards;

namespace CrossPlatformLibrary.Messaging
{
    internal class PhoneCallTask : IPhoneCallTask
    {
        public PhoneCallTask()
        {
        }

        public bool CanMakePhoneCall
        {
            get
            {
#if WINDOWS_UWP
                return Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager");
#else
                return true;
#endif
            }
        }

        public void MakePhoneCall(string number, string name = null)
        {
            Guard.ArgumentNotNullOrEmpty(number, nameof(number));

            if (this.CanMakePhoneCall)
            {
                PhoneCallManager.ShowPhoneCallUI(number, name ?? "");
            }
        }
    }
}
