namespace ApplicationLogger.Api.Util
{
    using AutoMapper;
    using Data.Models;
    using ViewModel;

    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<UserViewModel, UserInfo>();
            CreateMap<UserInfo, UserViewModel>();
            CreateMap<LogViewModel, ApplicationLog>();
            CreateMap<ApplicationLog, LogViewModel>();
        }
    }
}