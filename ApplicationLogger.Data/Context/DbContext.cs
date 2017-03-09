namespace ApplicationLogger.Data.Context
{
    using System.Configuration;
    using System.Data;
    using MySql.Data.MySqlClient;

    public class DbContext : IDbContext
    {
        public IDbCommand Command { get; private set; }

        public IDbConnection Connection { get; private set; }


        public DbContext()
        {
            var cmd = new MySqlCommand();
            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationLoggerConnectionString"].ConnectionString;
            Command = new MySqlCommand();
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Command.Dispose();
        }
    }
}
