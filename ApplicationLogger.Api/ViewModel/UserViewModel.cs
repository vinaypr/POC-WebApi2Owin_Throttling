namespace ApplicationLogger.Api.ViewModel
{
    public class UserViewModel : BaseResult
    {
        public string UserId { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }
    }
}
