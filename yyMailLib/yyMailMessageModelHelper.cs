using MimeKit;

namespace yyMailLib
{
    public static class yyMailMessageModelHelper
    {
        public static void Load (this MimeMessage message, yyMailMessageModel model)
        {
            if (model.Bcc != null)
                message.Bcc.AddRange (model.Bcc.Select (x => new MailboxAddress (x.Name, x.Address)));

            if (model.Cc != null)
                message.Cc.AddRange (model.Cc.Select (x => new MailboxAddress (x.Name, x.Address)));

            if (model.DateUtc != null)
                message.Date = model.DateUtc.Value;

            if (model.From != null)
                message.From.AddRange (model.From.Select (x => new MailboxAddress (x.Name, x.Address)));

            if (model.Headers != null)
            {
                foreach (var xHeader in model.Headers)
                    message.Headers.Add (xHeader.Key, xHeader.Value);
            }

            if (model.Importance != null)
                message.Importance = model.Importance.Value;

            if (model.InReplyTo != null)
                message.InReplyTo = model.InReplyTo;

            if (model.MessageId != null)
                message.MessageId = model.MessageId;

            if (model.MimeVersion != null)
                message.MimeVersion = model.MimeVersion;

            if (model.Priority != null)
                message.Priority = model.Priority.Value;

            if (model.References != null)
                message.References.AddRange (model.References);

            if (model.ReplyTo != null)
                message.ReplyTo.AddRange (model.ReplyTo.Select (x => new MailboxAddress (x.Name, x.Address)));

            if (model.Sender != null)
                message.Sender = new MailboxAddress (model.Sender.Name, model.Sender.Address);

            if (model.Subject != null)
                message.Subject = model.Subject;

            if (model.To != null)
                message.To.AddRange (model.To.Select (x => new MailboxAddress (x.Name, x.Address)));

            if (model.XPriority != null)
                message.XPriority = model.XPriority.Value;

            // If there's nothing at all to output, BodyBuilder creates a message with "Content-Type: text/plain; charset=utf-8" and no content.
            // We could also say an empty string is the mail body.

            // If there's one, we get a single part message with the right "Content-Type".

            // If there are 2 or more, we get a multipart message with the right "Content-Type" and a "boundary" parameter.

            // So, no reason to check the actual number of parts or determine whether to update message.Body or not.

            BodyBuilder xBodyBuilder = new ();

            if (string.IsNullOrWhiteSpace (model.HtmlBody) == false)
                xBodyBuilder.HtmlBody = model.HtmlBody;

            if (string.IsNullOrWhiteSpace (model.TextBody) == false)
                xBodyBuilder.TextBody = model.TextBody;

            if (model.Attachments != null)
            {
                foreach (var xAttachment in model.Attachments)
                {
                    xBodyBuilder.Attachments.Add (new MimePart (MimeTypes.GetMimeType (xAttachment.OriginalFilePath))
                    {
                        FileName = xAttachment.NewFileName ?? Path.GetFileName (xAttachment.OriginalFilePath),
                        ContentDisposition = new ContentDisposition (ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        Content = new MimeContent (new MemoryStream (File.ReadAllBytes (xAttachment.OriginalFilePath!))) // Avoids memory leakage.
                    });
                }
            }

            message.Body = xBodyBuilder.ToMessageBody ();
        }
    }
}
