namespace ApplicationLogger.Services
{
    using Data.Models;

    public interface ILoggerService
    {
        UserInfo Register(UserInfo userInfo);

        ApplicationLog AddApplicationLogger(ApplicationLog log);

        UserInfo GetUserInfo(string applicationId, string secret);
    }
}
