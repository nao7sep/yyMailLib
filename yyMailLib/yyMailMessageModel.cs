using System.Text.Json.Serialization;

namespace yyMailLib
{
    public class yyMailMessageModel
    {
        // Basically, everything that is not Resent* from the following page:
        // http://www.mimekit.net/docs/html/T_MimeKit_MimeMessage.htm

        // Regarding encoding settings, ChatGPT says:

            // In MimeKit, there's generally no need to explicitly set UTF-8 encoding for standard email components 
            // like the subject line, body, or address headers. MimeKit is engineered to automatically handle these encodings.

            // For the subject line and headers, MimeKit encodes them using 'encoded-word' syntax (RFC 2047) 
            // if they contain non-ASCII characters. This encoding is done in either 'B' encoding (akin to Base64) 
            // or 'Q' encoding (similar to Quoted-Printable), chosen based on efficiency for the given text.

            // When creating a TextPart for the email body and assigning text to it, MimeKit defaults to UTF-8 encoding 
            // if the text includes non-ASCII characters. This applies to both plain text and HTML content. 
            // Therefore, there's no need to manually specify UTF-8 encoding for these parts.

            // Address fields, such as 'From', 'To', and 'Cc', are also automatically handled by MimeKit. 
            // If the display name in these fields has non-ASCII characters, MimeKit encodes them appropriately.

            // For attachments and other binary parts of the email, the encoding is more about how the binary data 
            // is transferred (like Base64) rather than character encoding (UTF-8).

            // Overall, MimeKit's default behavior efficiently manages necessary encodings, including UTF-8 where appropriate, 
            // reducing the need for manual settings or interventions in the encoding process.

        [JsonPropertyName ("attachments")]
        public IList <yyMailMessageAttachmentModel>? Attachments { get; set; }

        [JsonPropertyName ("bcc")]
        public IList <yyMailContactModel>? Bcc { get; set; }

        [JsonPropertyName ("cc")]
        public IList <yyMailContactModel>? Cc { get; set; }

        // The name may appear redundant.
        // Just making sure.
        // Everything will be hand-copied to MimeMessage.

        [JsonPropertyName ("date_utc")]
        public DateTime? DateUtc { get; set; }

        [JsonPropertyName ("from")]
        public yyMailContactModel? From { get; set; }

        [JsonPropertyName ("headers")]
        public IDictionary <string, string>? Headers { get; set; }

        [JsonPropertyName ("html_body")]
        public string? HtmlBody { get; set; }
        
        [JsonPropertyName ("html_body_translations")]
        public IList <yyMailMessageTranslationModel>? HtmlBodyTranslations { get; set; }

        [JsonPropertyName ("importance")]
        public yyMailMessageImportance? Importance { get; set; }

        [JsonPropertyName ("in_reply_to")]
        public string? InReplyTo { get; set; }

        [JsonPropertyName ("language")]
        public string? Language { get; set; }

        [JsonPropertyName ("message_id")]
        public string? MessageId { get; set; }

        [JsonPropertyName ("mime_version")]
        public string? MimeVersion { get; set; }

        [JsonPropertyName ("priority")]
        public yyMailMessagePriority? Priority { get; set; }

        [JsonPropertyName ("references")]
        public IList <string>? References { get; set; }

        [JsonPropertyName ("reply_to")]
        public yyMailContactModel? ReplyTo { get; set; }

        [JsonPropertyName ("sender")]
        public yyMailContactModel? Sender { get; set; }

        [JsonPropertyName ("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName ("subject_translations")]
        public IList <yyMailMessageTranslationModel>? SubjectTranslations { get; set; }

        [JsonPropertyName ("text_body")]
        public string? TextBody { get; set; }

        [JsonPropertyName ("text_body_translations")]
        public IList <yyMailMessageTranslationModel>? TextBodyTranslations { get; set; }

        [JsonPropertyName ("to")]
        public IList <yyMailContactModel>? To { get; set; }

        [JsonPropertyName ("x_priority")]
        public yyMailMessageXPriority? XPriority { get; set; }
    }
}
