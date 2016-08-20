using System.Collections.Generic;

namespace CrossPlatformLibrary.Messaging
{
    /// <summary>
    ///     Email used for sending e-mails.
    /// </summary>
    internal class EmailMessage : IEmailMessage
    {
        private List<string> recipientsBcc;
        private List<string> recipientsCc;
        private List<string> recipients;
        private List<IEmailAttachment> attachments;

        /// <summary>
        ///     Create new email request
        /// </summary>
        /// <param name="to">Email recipient</param>
        public EmailMessage(string to)
            : this()
        {
            if (!string.IsNullOrWhiteSpace(to))
            {
                this.Recipients.Add(to);
            }
        }

        /// <summary>
        ///     Create new email request
        /// </summary>
        /// <param name="to">Email recipient</param>
        /// <param name="subject">Email subject</param>
        /// <param name="message">Email message</param>
        public EmailMessage(string to = null, string subject = null, string message = null)
            : this(to)
        {
            this.Subject = subject ?? string.Empty;
            this.Message = message ?? string.Empty;
        }

        /// <summary>
        ///     Constructor used by the <see cref="EmailMessageBuilder" />
        /// </summary>
        internal EmailMessage()
        {
            this.Subject = string.Empty;
            this.Message = string.Empty;
        }

        /// <summary>
        ///     Email message body.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or set a value indicating whether the <see cref="Message" /> is HTML content
        ///     or plain text.
        /// </summary>
        /// <remarks>
        ///     HTML content type is only supported on Android and iOS platforms
        /// </remarks>
        public bool IsHtml { get; set; }

        /// <summary>
        ///     List of attachments.
        /// </summary>
        public List<IEmailAttachment> Attachments
        {
            get
            {
                return this.attachments ?? (this.attachments = new List<IEmailAttachment>());
            }
            set
            {
                this.attachments = value;
            }
        }

        /// <summary>
        ///     List of To recipients
        /// </summary>
        public List<string> Recipients
        {
            get
            {
                return this.recipients ?? (this.recipients = new List<string>());
            }
            set
            {
                this.recipients = value;
            }
        }

        /// <summary>
        ///     List of Bcc recipients
        /// </summary>
        public List<string> RecipientsBcc
        {
            get
            {
                return this.recipientsBcc ?? (this.recipientsBcc = new List<string>());
            }
            set
            {
                this.recipientsBcc = value;
            }
        }

        /// <summary>
        ///     List of Cc recipients
        /// </summary>
        public List<string> RecipientsCc
        {
            get
            {
                return this.recipientsCc ?? (this.recipientsCc = new List<string>());
            }
            set
            {
                this.recipientsCc = value;
            }
        }

        /// <summary>
        ///     Email subject
        /// </summary>
        public string Subject { get; set; }
    }
}