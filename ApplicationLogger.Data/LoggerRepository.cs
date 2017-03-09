namespace ApplicationLogger.Data
{
    using Context;
    using ApplicationLogger.Data.Models;
    using System;
    using Extensions;

    public class LoggerRepository : ILoggerRepository
    {
        private readonly IDbContext _dbContext;
        public LoggerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationLog AddApplicationLogger(ApplicationLog log)
        {
            using(var connection = _dbContext.Connection)
            {
                using (var command = _dbContext.Command)
                {
                    try
                    {
                        var insertCommandString = @"insert into ApplicationLogger.ApplicationLog(UserId,logger,level,message) 
                            values(@UserId, @Logger, @Level, @Message);
                            Select LAST_INSERT_ID();"
                        ;
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = insertCommandString;
                        command.CommandType = System.Data.CommandType.Text;

                        command.Parameters.Clear();
                        command.AddParameter("@UserId", log.UserId);
                        command.AddParameter("@Logger", log.Logger);
                        command.AddParameter("@Level", log.Level);
                        command.AddParameter("@Message", log.Message);

                        log.LogId = Convert.ToInt32(command.ExecuteScalar());
                            
                        return log;
                    }
                    finally
                    {
                        connection.Close();
                    }
                    
                }
            } 
        }

        public UserInfo Register(UserInfo userInfo)
        {
            using (var connection = _dbContext.Connection)
            {
                using (var command = _dbContext.Command)
                {
                    try
                    {
                        var insertCommandString = @"insert into ApplicationLogger.UserInfo(UserId,DisplayName,UserPassword) 
                            values(@UserId, @DisplayName, @Password)";

                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = insertCommandString;
                        command.CommandType = System.Data.CommandType.Text;

                        command.Parameters.Clear();
                        command.AddParameter("@UserId", userInfo.UserId);
                        command.AddParameter("@Displayname", userInfo.DisplayName);
                        command.AddParameter("@Password", userInfo.Password);

                        command.ExecuteNonQuery();
                        return userInfo;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public UserInfo GetUserInfoById(string userId)
        {
            UserInfo result = null;

            using (var connection = _dbContext.Connection)
            {
                using (var command = _dbContext.Command)
                {
                    try
                    {
                        var insertCommandString = @"select UserId, DisplayName, UserPassword from ApplicationLogger.UserInfo 
                            where UserId =  @UserId";

                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = insertCommandString;
                        command.CommandType = System.Data.CommandType.Text;
                        command.Parameters.Clear();
                        command.AddParameter("@UserId", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = new UserInfo
                                {
                                    UserId = Convert.ToString(reader["UserId"]),
                                    Password = Convert.ToString(reader["UserPassword"]),
                                    DisplayName = Convert.ToString(reader["DisplayName"])
                                };
                            }
                        }
                        
                        return result;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public UserInfo GetUserInfo(string userId, string secret)
        {
            UserInfo result = null;

            using (var connection = _dbContext.Connection)
            {
                using (var command = _dbContext.Command)
                {
                    try
                    {
                        var insertCommandString = @"select UserId, DisplayName, UserPassword from ApplicationLogger.UserInfo 
                            where UserId =  @UserId and UserPassword = @Password";

                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = insertCommandString;
                        command.CommandType = System.Data.CommandType.Text;
                        command.Parameters.Clear();
                        command.AddParameter("@UserId", userId);
                        command.AddParameter("@Password", secret);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = new UserInfo
                                {
                                    UserId = Convert.ToString(reader["UserId"]),
                                    Password = Convert.ToString(reader["UserPassword"]),
                                    DisplayName = Convert.ToString(reader["DisplayName"])
                                };
                            }
                        }

                        return result;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
