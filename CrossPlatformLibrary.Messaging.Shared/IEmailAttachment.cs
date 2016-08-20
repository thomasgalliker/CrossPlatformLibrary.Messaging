namespace CrossPlatformLibrary.Messaging
{
    public interface IEmailAttachment
    {
        string FileName { get; }

        string ContentType { get; }
    }
}