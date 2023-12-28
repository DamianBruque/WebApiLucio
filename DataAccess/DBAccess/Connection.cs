using System.Data;

namespace DataAccess.DBAccess
{
    public class Connection : IConnection
    {
        private readonly IDbConnection dbConnection;
        public Connection(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            dbConnection.ConnectionString = Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING");
        }
        public IDbConnection GetConnection()
        {
            return dbConnection;
        }
    }
}
