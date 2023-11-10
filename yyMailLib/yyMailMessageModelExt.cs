using MimeKit;

namespace yyMailLib
{
    public static class yyMailMessageModelExt
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

            BodyBuilder bodyBuilder = new ();

            if (string.IsNullOrWhiteSpace (model.HtmlBody) == false)
                bodyBuilder.HtmlBody = model.HtmlBody;

            if (string.IsNullOrWhiteSpace (model.TextBody) == false)
                bodyBuilder.TextBody = model.TextBody;

            if (model.Attachments != null)
            {
                foreach (var xAttachment in model.Attachments)
                {
                    bodyBuilder.Attachments.Add (new MimePart (MimeTypes.GetMimeType (xAttachment.OriginalFilePath))
                    {
                        FileName = xAttachment.NewFileName ?? Path.GetFileName (xAttachment.OriginalFilePath),
                        ContentDisposition = new ContentDisposition (ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        Content = new MimeContent (File.OpenRead (xAttachment.OriginalFilePath!))
                    });
                }
            }

            message.Body = bodyBuilder.ToMessageBody ();
        }
    }
}
