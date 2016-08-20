﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformLibrary.Messaging
{
    public interface IEmailMessage
    {
        /// <summary>
        ///     Email message body.
        /// </summary>
        string Message { get; }

        /// <summary>
        ///     List of attachments.
        /// </summary>
        /// <remarks>
        ///     Not supported on Windows Phone and Windows Store platform
        /// </remarks>
        List<IEmailAttachment> Attachments { get; }

        /// <summary>
        ///     List of To recipients
        /// </summary>
        List<string> Recipients { get; }

        /// <summary>
        ///     List of Bcc recipients
        /// </summary>
        List<string> RecipientsBcc { get; }

        /// <summary>
        ///     List of Cc recipients
        /// </summary>
        List<string> RecipientsCc { get; }

        /// <summary>
        ///     Email subject
        /// </summary>
        string Subject { get; }
    }
}
