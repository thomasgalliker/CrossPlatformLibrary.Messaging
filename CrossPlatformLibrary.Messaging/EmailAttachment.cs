using System.IO;

using CrossPlatformLibrary.Utils;

namespace CrossPlatformLibrary.Messaging
{
    public class EmailAttachment
    {
        /// <summary>
        ///     Create a new attachment. Use on Android platform or WinPhoneRT as we
        ///     only require the file.
        /// </summary>
        /// <param name="fileName">File location</param>
        public EmailAttachment(string fileName)
        {
            Guard.ArgumentNotNullOrEmpty(() => fileName);

            this.FileName = fileName;
        }

        /// <summary>
        ///     Create a new attachment.  Use on iOS platform as we require all
        ///     parameter info
        /// </summary>
        /// <param name="fileName">File location</param>
        /// <param name="content">File contents</param>
        /// <param name="contentType">File content type</param>
        public EmailAttachment(string fileName, Stream content, string contentType)
            : this(fileName)
        {
            Guard.ArgumentNotNull(() => content);
            Guard.ArgumentNotNullOrEmpty(() => contentType);

            this.Content = content;
            this.ContentType = contentType;
        }

        /// <summary>
        ///     Gets or sets the file content. Required on iOS.
        /// </summary>
        public Stream Content { get; private set; }

        /// <summary>
        ///     Gets the file content type. Required on iOS.
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        ///     Gets the file location.
        /// </summary>
        public string FileName { get; private set; }
    }
}