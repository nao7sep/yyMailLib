using MailKit;

namespace yyMailLib
{
    public static class yyMailConnectionInfoModelHelper
    {
        public static async Task ConnectAsync (this IMailService service, yyMailConnectionInfoModel connectionInfo, CancellationToken? cancellationToken = null) =>
            await service.ConnectAsync (connectionInfo.Host, connectionInfo.Port!.Value, connectionInfo.SecureSocketOptions!.Value, cancellationToken ?? CancellationToken.None);

        public static async Task AuthenticateAsync (this IMailService service, yyMailConnectionInfoModel connectionInfo, CancellationToken? cancellationToken = null) =>
            await service.AuthenticateAsync (connectionInfo.UserName, connectionInfo.Password, cancellationToken ?? CancellationToken.None);
    }
}
