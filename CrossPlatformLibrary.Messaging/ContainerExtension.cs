using CrossPlatformLibrary.IoC;

namespace CrossPlatformLibrary.Messaging
{
    public class ContainerExtension : IContainerExtension
    {
        public void Initialize(ISimpleIoc container)
        {
            container.RegisterPlatformSpecific<IEmailTask>();
            container.RegisterPlatformSpecific<IPhoneCallTask>();
            container.RegisterPlatformSpecific<ISmsTask>();
        }
    }
}
