using System.Collections.Generic;

namespace CrossPlatformLibrary.Messaging
{
    /// <summary>
    ///     Builder pattern for constructing a <see cref="EmailMessage" />
    /// </summary>
    public class EmailMessageBuilder
    {
        private readonly EmailMessage email;

        public EmailMessageBuilder()
        {
            this.email = new EmailMessage();
        }

        public EmailMessageBuilder Bcc(string bcc)
        {
            if (!string.IsNullOrWhiteSpace(bcc))
            {
                this.email.RecipientsCc.Add(bcc);
            }

            return this;
        }

        public EmailMessageBuilder Bcc(IEnumerable<string> bcc)
        {
            this.email.RecipientsCc.AddRange(bcc);
            return this;
        }

        public EmailMessageBuilder Body(string body)
        {
            if (!string.IsNullOrEmpty(body))
            {
                this.email.Message = body;
            }

            return this;
        }

#if __ANDROID__ || __IOS__

        public EmailMessageBuilder BodyAsHtml(string htmlBody)
        {
            if (!string.IsNullOrEmpty(htmlBody))
            {                
                _email.Message = htmlBody;
                _email.IsHtml = true;
            }

            return this;
        }

#endif

#if __ANDROID__

    /// <summary>
    ///     Add the file located at <paramref name="filePath"/> as an attachment
    /// </summary>
    /// <param name="filePath">Full path to the file to attach</param>
        public EmailMessageBuilder WithAttachment(string filePath)
        {
            _email.Attachments.Add(new EmailAttachment(filePath));
            return this;
        }

#elif __IOS__

    /// <summary>
    ///     Add the <paramref name="content"/> as an attachment to the email.
    /// </summary>
    /// <param name="fileName">File name</param>
    /// <param name="content">File content</param>
    /// <param name="contentType">File content type (image/jpeg etc.)</param>
        public EmailMessageBuilder WithAttachment(string fileName, System.IO.Stream content, string contentType)
        {
            _email.Attachments.Add(new EmailAttachment(fileName, content, contentType));
            return this;
        }

#elif WINDOWS_PHONE_APP

        public EmailMessageBuilder WithAttachment(Windows.Storage.IStorageFile file)
        {
            _email.Attachments.Add(new EmailAttachment(file));
            return this;
        }

#endif

        public EmailMessage Build()
        {
            return this.email;
        }

        public EmailMessageBuilder Cc(string cc)
        {
            if (!string.IsNullOrWhiteSpace(cc))
            {
                this.email.RecipientsCc.Add(cc);
            }

            return this;
        }

        public EmailMessageBuilder Cc(IEnumerable<string> cc)
        {
            this.email.RecipientsCc.AddRange(cc);
            return this;
        }

        public EmailMessageBuilder Subject(string subject)
        {
            if (!string.IsNullOrEmpty(subject))
            {
                this.email.Subject = subject;
            }

            return this;
        }

        public EmailMessageBuilder To(string to)
        {
            if (!string.IsNullOrWhiteSpace(to))
            {
                this.email.Recipients.Add(to);
            }

            return this;
        }

        public EmailMessageBuilder To(IEnumerable<string> to)
        {
            this.email.Recipients.AddRange(to);
            return this;
        }
    }
}