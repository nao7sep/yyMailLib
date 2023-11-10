using System.Text.Json.Serialization;

namespace yyMailLib
{
    public class yyMailMessageAttachmentModel
    {
        // To attach a file, we set OriginalFilePath and, optionally, NewFileName.
        // Before the message is sent, the attachment file is copied and its new path, that is relative to the location of the app, is stored in the model.
        // We have the absolute path of the new base directory, so the current absolute path doesnt need to be in the model.

        // http://www.mimekit.net/docs/html/T_MimeKit_MimeEntity.htm
        // http://www.mimekit.net/docs/html/T_MimeKit_ContentDisposition.htm

        [JsonPropertyName ("original_file_path")]
        public string? OriginalFilePath { get; set; }

        [JsonPropertyName ("new_file_name")]
        public string? NewFileName { get; set; }

        [JsonPropertyName ("current_relative_file_path")]
        public string? CurrentRelativeFilePath { get; set; }

        [JsonPropertyName ("creation_utc")]
        public DateTime? CreationUtc { get; set; }

        [JsonPropertyName ("modification_utc")]
        public DateTime? ModificationUtc { get; set; }

        [JsonPropertyName ("read_utc")]
        public DateTime? ReadUtc { get; set; }

        [JsonPropertyName ("content_length")]
        public long? ContentLength { get; set; }
    }
}
