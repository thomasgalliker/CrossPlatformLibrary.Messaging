namespace CrossPlatformLibrary.Messaging
{
    public class PhoneCallTask : IPhoneCallTask
    {
        public bool CanMakePhoneCall
        {
            get
            {
                throw new NotImplementedInReferenceAssemblyException();
            }
        }

        public void MakePhoneCall(string number, string name = null)
        {
            throw new NotImplementedInReferenceAssemblyException();
        }
    }
}