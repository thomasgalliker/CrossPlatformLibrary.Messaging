using System;

namespace CrossPlatformLibrary.Messaging
{
    internal class SmsTask : ISmsTask
    {
        public bool CanSendSms
        {
            get { return false; }
        }

        public void SendSms(string recipient, string message)
        {
            throw new PlatformNotSupportedException("Sending SMS not supported on Windows Store");
        }
    }
}
