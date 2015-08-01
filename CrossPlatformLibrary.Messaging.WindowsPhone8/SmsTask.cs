using Microsoft.Phone.Tasks;

using CrossPlatformLibrary.Utils;

namespace CrossPlatformLibrary.Messaging
{
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
            Guard.ArgumentNotNullOrEmpty(() => recipient);
            Guard.ArgumentNotNullOrEmpty(() => message);

            if (this.CanSendSms)
            {
                SmsComposeTask smsComposeTask = new SmsComposeTask { To = recipient, Body = message };

                smsComposeTask.Show();
            }
        }
    }
}