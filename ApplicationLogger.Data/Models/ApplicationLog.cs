namespace ApplicationLogger.Data.Models
{
    public class ApplicationLog
    {
        public int LogId { get; set; }

        public string UserId { get; set; }

        public string Logger { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }
    }
}
