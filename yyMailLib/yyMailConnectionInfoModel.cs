using System.Text.Json.Serialization;

namespace yyMailLib
{
    public class yyMailConnectionInfoModel
    {
        // Minimal info to use the following class:
        // http://www.mimekit.net/docs/html/T_MailKit_Net_Smtp_SmtpClient.htm

        [JsonPropertyName ("host")]
        public string? Host { get; set; }

        [JsonPropertyName ("port")]
        public int? Port { get; set; }

        [JsonPropertyName ("secure_socket_options")]
        public yyMailSecureSocketOptions? SecureSocketOptions { get; set; }

        [JsonPropertyName ("user_name")]
        public string? UserName { get; set; }

        [JsonPropertyName ("password")]
        public string? Password { get; set; }
    }
}
