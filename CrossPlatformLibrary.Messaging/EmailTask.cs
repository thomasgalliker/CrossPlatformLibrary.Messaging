namespace CrossPlatformLibrary.Messaging
{
    public class EmailTask : IEmailTask
    {
        public bool CanSendEmail
        {
            get
            {
                throw new NotImplementedInReferenceAssemblyException();
            }
        }

        public void SendEmail(EmailMessage email)
        {
            throw new NotImplementedInReferenceAssemblyException();
        }

        public void SendEmail(string to, string subject, string message)
        {
            throw new NotImplementedInReferenceAssemblyException();
        }
    }
}