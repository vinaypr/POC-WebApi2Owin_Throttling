namespace ApplicationLogger.Api.Controllers.V1
{
    using ApplicationLogger.Services;
    using AutoMapper;
    using Data.Models;
    using System;
    using System.Web.Http;
    using ViewModel;

    public class LoggerController : ApiController
    {
        private readonly ILoggerService _loggerService;

        private readonly IMapper _mapper;

        public LoggerController(ILoggerService loggerService, IMapper mapper)
        {
            _loggerService = loggerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route(Routes.LoggerConfig.AddApplicationLogger.Path, Name = Routes.LoggerConfig.AddApplicationLogger.Name)]
        public IHttpActionResult AddApplicationLogger([FromBody] LogViewModel log)
        {
            LogViewModel result = null;
            try
            {            
                var logObj = _mapper.Map<ApplicationLog>(log);
                var logResult = _loggerService.AddApplicationLogger(logObj);
                if(logResult != null)
                {
                    result = _mapper.Map<LogViewModel>(logResult);
                }
            }
            catch (Exception ex)
            {
                result = new LogViewModel { ErroMessage = ex.Message, HasError = true };
            }

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(Routes.LoggerConfig.Register.Path, Name = Routes.LoggerConfig.Register.Name)]
        public IHttpActionResult Register(UserViewModel userViewModel)
        {
            if (string.IsNullOrEmpty(userViewModel.DisplayName))
            {
                return BadRequest("Please provide application display message.");
            }

            UserViewModel result = null;

            try
            {
                var userInfoObj = _mapper.Map<UserInfo>(userViewModel);
                var serviceResult = _loggerService.Register(userInfoObj);
                if(serviceResult != null)
                {
                    result = _mapper.Map<UserViewModel>(serviceResult);
                }
            }
            catch (Exception ex)
            {
                result = new UserViewModel { ErroMessage = ex.Message, HasError = true };
            }

            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
