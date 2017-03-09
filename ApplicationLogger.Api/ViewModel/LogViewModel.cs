namespace ApplicationLogger.Api.ViewModel
{
    public class LogViewModel : BaseResult
    {
        public string UserId { get; set; }

        public string Logger { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }
    }
}
