namespace ApplicationLogger.Services
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using System;

    public class LoggerService : ILoggerService
    {
        private readonly ILoggerRepository _loggerRepository;

        public LoggerService(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }
        public ApplicationLog AddApplicationLogger(ApplicationLog log)
        {
            // convert result to business entities and perform any business logic
            ApplicationLog result = null;

            var userInfo = _loggerRepository.GetUserInfoById(log.UserId);
            if(userInfo != null)
            {
                result = _loggerRepository.AddApplicationLogger(log);
            }

            return result;
        }

        public UserInfo Register(UserInfo userInfo)
        {
            UserInfo result = null;
            // convert result to business entities and perform any business logic
            var user = _loggerRepository.GetUserInfoById(userInfo.UserId);
            if(user == null)
            {
                result = _loggerRepository.Register(userInfo);
            }

            return result;
        }

        public UserInfo GetUserInfo(string applicationId, string secret)
        {
            // convert result to business entities and perform any business logic
            return _loggerRepository.GetUserInfo(applicationId, secret);
            //ApplicationViewModel result = null;
            //try
            //{
            //    var applicationObj = _loggerRepository.GetApplication(applicationId, secret);
            //    if (applicationObj != null)
            //    {
            //        result = _mapper.Map<ApplicationViewModel>(applicationObj);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    result = new ApplicationViewModel { ErroMessage = ex.Message, HasError = true };
            //}

            //return result;
        }
    }
}
