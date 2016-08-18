namespace CrossPlatformLibrary.Messaging
{
    public class SmsTask : ISmsTask
    {
        public bool CanSendSms
        {
            get
            {
                throw new NotImplementedInReferenceAssemblyException();
            }
        }

        public void SendSms(string recipient, string message)
        {
            throw new NotImplementedInReferenceAssemblyException();
        }
    }
}