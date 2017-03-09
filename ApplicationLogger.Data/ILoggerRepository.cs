namespace ApplicationLogger.Data
{
    using ApplicationLogger.Data.Models;

    public interface ILoggerRepository
    {
        UserInfo Register(UserInfo userInfo);

        ApplicationLog AddApplicationLogger(ApplicationLog log);

        UserInfo GetUserInfoById(string userId);

        UserInfo GetUserInfo(string userId, string secret);
    }
}
