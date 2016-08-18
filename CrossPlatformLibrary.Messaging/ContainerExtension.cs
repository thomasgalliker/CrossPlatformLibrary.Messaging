using CrossPlatformLibrary.IoC;

namespace CrossPlatformLibrary.Messaging
{
    public class ContainerExtension : IContainerExtension
    {
        public void Initialize(ISimpleIoc container)
        {
            container.Register<IEmailTask, EmailTask>();
            container.Register<IPhoneCallTask, PhoneCallTask>();
            container.Register<ISmsTask, SmsTask>();
        }
    }
}
