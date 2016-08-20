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

        public bool CanSendEmailAttachments
        {
            get
            {
                throw new NotImplementedInReferenceAssemblyException();
            }
        }

        public bool CanSendEmailBodyAsHtml
        {
            get
            {
                throw new NotImplementedInReferenceAssemblyException();
            }
        }

        public void SendEmail(IEmailMessage email)
        {
            throw new NotImplementedInReferenceAssemblyException();
        }

        public void SendEmail(string to, string subject, string message)
        {
            throw new NotImplementedInReferenceAssemblyException();
        }
    }
}