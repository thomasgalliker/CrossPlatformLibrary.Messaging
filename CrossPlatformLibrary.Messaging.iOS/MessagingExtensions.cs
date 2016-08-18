#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace CrossPlatformLibrary.Messaging
{
    internal static class MessagingExtensions
    {
        internal static void PresentUsingRootViewController(this UIViewController controller)
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, () => { });
        }
    }
}