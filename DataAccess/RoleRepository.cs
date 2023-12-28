
using DataAccess.DBAccess;
using Models;
using Oracle.ManagedDataAccess.Client;
using Repositories;
using System.Data;
using Utilities.Exceptions;

namespace DataAccess
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IConnection connection;
        public RoleRepository(IConnection connection) 
        {
            this.connection = connection;
        }

        public Task<IEnumerable<RoleEntity>> GetAll()
        {
            try
            {
                OracleDataReader reader;
                OracleCommand command = new OracleCommand("SYSTEM.ROLE_GETALL", (OracleConnection)connection.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("roles", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                connection.GetConnection().Open();
                reader = command.ExecuteReader();
                List<RoleEntity> roles = new List<RoleEntity>();
                while (reader.Read())
                {
                    roles.Add(new RoleEntity
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = Convert.ToString(reader["name"])
                    });
                }
                return Task.FromResult(roles.AsEnumerable());
            }
            catch (Exception e)
            {
                throw new DatabaseQueryErrorException(e.Message);
            }
            finally
            {
                connection.GetConnection().Close();
            }
        }

        // usamos el stored procedure role_getbyname para obtener el rol por nombre

        public Task<RoleEntity> GetByName(string name)
        {
            try
            {
                OracleDataReader reader;
                OracleCommand command = new OracleCommand("role_getbyname", (OracleConnection)connection.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
                connection.GetConnection().Open();
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Task.FromResult(new RoleEntity
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = Convert.ToString(reader["name"])
                    });
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new DatabaseQueryErrorException(e.Message);
            }
            finally
            {
                connection.GetConnection().Close();
            }

        }
    }
}
