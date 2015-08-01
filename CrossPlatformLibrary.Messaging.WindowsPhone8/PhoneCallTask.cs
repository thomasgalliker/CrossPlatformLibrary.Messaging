using CrossPlatformLibrary.Tracing;
using CrossPlatformLibrary.Utils;

namespace CrossPlatformLibrary.Messaging
{
    public class PhoneCallTask : IPhoneCallTask
    {
        private readonly ITracer tracer;

        public PhoneCallTask(ITracer tracer)
        {
            Guard.ArgumentNotNull(() => tracer);

            this.tracer = tracer;
        }

        public bool CanMakePhoneCall
        {
            get
            {
                return true;
            }
        }

        public void MakePhoneCall(string number, string name = null)
        {
            Guard.ArgumentNotNullOrEmpty(() => number);

            // NOTE: Requires ID_CAP_PHONEDIALER capabilities
            if (this.CanMakePhoneCall)
            {
                Microsoft.Phone.Tasks.PhoneCallTask dialer = new Microsoft.Phone.Tasks.PhoneCallTask
                {
                    PhoneNumber = number,
                    DisplayName = name ?? ""
                };

                this.tracer.Debug("MakePhoneCall with number={0} and name={1}", number, name);
                dialer.Show();
            }
        }
    }
}