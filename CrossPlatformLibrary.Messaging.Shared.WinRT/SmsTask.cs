using Windows.ApplicationModel.Chat;

namespace CrossPlatformLibrary.Messaging
{
    internal class SmsTask : ISmsTask
    {
        public bool CanSendSms { get { return true; } }

        public void SendSms(string recipient = null, string message = null)
        {
            message = message ?? string.Empty;

            if (this.CanSendSms)
            {
                var msg = new ChatMessage { Body = message };
                if (!string.IsNullOrWhiteSpace(recipient))
                {
                    msg.Recipients.Add(recipient);
                }

#pragma warning disable 4014
                ChatMessageManager.ShowComposeSmsMessageAsync(msg);
#pragma warning restore 4014
            }
        }
    }
}
