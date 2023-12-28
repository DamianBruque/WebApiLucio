using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DataAccess.DBAccess
{
    public class OracleDbConnection : IConnection
    {
        private readonly OracleConnection dbConnection;// = new OracleConnection(Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING")); //"Data Source=//localhost:1521/xe;User Id=sys;Password=ReCoilGammer;DBA Privilege=SYSDBA");
        public OracleDbConnection()
        {
            dbConnection = new OracleConnection(Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING"));
        }
        

        public IDbConnection GetConnection()
        {
            return dbConnection;
        }
    }
}
