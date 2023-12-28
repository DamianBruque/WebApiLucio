using System.Data;

namespace DataAccess.DBAccess
{
    public interface IConnection
    {
        public IDbConnection GetConnection();
    }
}
