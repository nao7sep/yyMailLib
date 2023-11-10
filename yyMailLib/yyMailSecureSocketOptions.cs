namespace yyMailLib
{
    // http://www.mimekit.net/docs/html/T_MailKit_Security_SecureSocketOptions.htm

    public enum yyMailSecureSocketOptions
    {
        None = 0,
        Auto = 1,
        SslOnConnect = 2,
        StartTls = 3,
        StartTlsWhenAvailable = 4
    }
}
