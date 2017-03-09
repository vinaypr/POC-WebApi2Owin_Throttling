namespace ApplicationLogger.Data.Context
{
    using System;
    using System.Data;

    public interface IDbContext : IDisposable
    {
        IDbCommand Command { get; }

        IDbConnection Connection { get; }
    }
}
