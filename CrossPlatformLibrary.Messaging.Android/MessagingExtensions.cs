using Android.Content;

using Guards;

namespace CrossPlatformLibrary.Messaging
{
    internal static class MessagingExtensions
    {
        public static void StartNewActivity(this Intent intent)
        {
            Guard.ArgumentNotNull(intent, nameof(intent));

            intent.SetFlags(ActivityFlags.ClearTop);
            intent.SetFlags(ActivityFlags.NewTask);

            Android.App.Application.Context.StartActivity(intent);
        }
    }
}