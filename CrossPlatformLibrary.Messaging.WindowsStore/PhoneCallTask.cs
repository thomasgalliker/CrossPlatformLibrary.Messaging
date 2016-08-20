using System;

namespace CrossPlatformLibrary.Messaging
{
    internal class PhoneCallTask : IPhoneCallTask
    {
        public bool CanMakePhoneCall
        {
            get { return false; }
        }

        public void MakePhoneCall(string number, string name = null)
        {
            throw new PlatformNotSupportedException("Making Phone call not supported on Windows Store");
        }
    }
}
