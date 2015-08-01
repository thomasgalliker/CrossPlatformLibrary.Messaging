using CrossPlatformLibrary.Utils;

#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace CrossPlatformLibrary.Messaging
{
    internal static class MessagingExtensions
    {
        public static void PresentUsingRootViewController(this UIViewController controller)
        {
            Guard.ArgumentNotNull(() => controller);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, () => { });
        }
    }
}