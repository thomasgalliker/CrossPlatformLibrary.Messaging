using CrossPlatformLibrary.IoC;

namespace CrossPlatformLibrary.Messaging
{
    public class ContainerExtension : IContainerExtension
    {
        public void Initialize(ISimpleIoc container)
        {
            container.RegisterWithConvention<IEmailTask>();
            container.RegisterWithConvention<IPhoneCallTask>();
            container.RegisterWithConvention<ISmsTask>();
        }
    }
}
