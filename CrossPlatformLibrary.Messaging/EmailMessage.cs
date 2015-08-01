using System.Collections.Generic;

using CrossPlatformLibrary.Utils;

namespace CrossPlatformLibrary.Messaging
{
    /// <summary>
    ///     Email used for sending e-mails.
    /// </summary>
    public class EmailMessage
    {
        private List<string> _recipientsBcc;
        private List<string> _recipientsCc;
        private List<string> _recipients;
        private List<EmailAttachment> _attachments;

        /// <summary>
        ///     Create new email request
        /// </summary>
        /// <param name="to">Email recipient</param>
        public EmailMessage(string to)
            : this()
        {
            Guard.ArgumentNotNullOrEmpty(() => to);
            
            this.Recipients.Add(to);
        }

        /// <summary>
        ///     Create new email request
        /// </summary>
        /// <param name="to">Email recipient</param>
        /// <param name="subject">Email subject</param>
        /// <param name="message">Email message</param>
        public EmailMessage(string to, string subject, string message)
            : this(to)
        {
            Guard.ArgumentNotNullOrEmpty(() => subject);
            Guard.ArgumentNotNullOrEmpty(() => message);

            this.Subject = subject;
            this.Message = message;
        }

        /// <summary>
        ///     Constructor used by the <see cref="EmailMessageBuilder" />
        /// </summary>
        internal EmailMessage()
        {
            this.Subject = string.Empty;
            this.Message = string.Empty;
        }

        #region Properties

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
        public List<EmailAttachment> Attachments
        {
            get
            {
                return this._attachments ?? (this._attachments = new List<EmailAttachment>());
            }
            set
            {
                this._attachments = value;
            }
        }

        /// <summary>
        ///     List of To recipients
        /// </summary>
        public List<string> Recipients
        {
            get
            {
                return this._recipients ?? (this._recipients = new List<string>());
            }
            set
            {
                this._recipients = value;
            }
        }

        /// <summary>
        ///     List of Bcc recipients
        /// </summary>
        public List<string> RecipientsBcc
        {
            get
            {
                return this._recipientsBcc ?? (this._recipientsBcc = new List<string>());
            }
            set
            {
                this._recipientsBcc = value;
            }
        }

        /// <summary>
        ///     List of Cc recipients
        /// </summary>
        public List<string> RecipientsCc
        {
            get
            {
                return this._recipientsCc ?? (this._recipientsCc = new List<string>());
            }
            set
            {
                this._recipientsCc = value;
            }
        }

        /// <summary>
        ///     Email subject
        /// </summary>
        public string Subject { get; set; }

        #endregion
    }
}