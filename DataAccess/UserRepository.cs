using DataAccess.DBAccess;
using Models;
using Oracle.ManagedDataAccess.Client;
using Repositories;
using Utilities.Exceptions;

namespace DataAccess;

public class UserRepository : IUserRepository
{
    private readonly IConnection connection;
    public UserRepository(IConnection dbConnection)
    {
        connection = dbConnection;
    }

    public Task<UserEntity> Create(UserEntity user)
    {
        try
        {
            OracleCommand command = new OracleCommand("user_insert", (OracleConnection)connection.GetConnection());
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("email", OracleDbType.Varchar2).Value = user.Email;
            command.Parameters.Add("password", OracleDbType.Varchar2).Value = user.Password;
            command.Parameters.Add("role_id", OracleDbType.Int32).Value = user.RoleId;
            connection.GetConnection().Open();
            command.ExecuteNonQuery();
            return Task.FromResult(user);
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

    public Task<UserEntity> GetByEmail(string email)
    {
        try
        {
            OracleDataReader reader;
            OracleCommand command = new OracleCommand("user_getbyemail", (OracleConnection)connection.GetConnection());
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("email", OracleDbType.Varchar2).Value = email;
            connection.GetConnection().Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                return Task.FromResult(new UserEntity
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Email = Convert.ToString(reader["email"]),
                    Password = Convert.ToString(reader["password"]),
                    RoleId = Convert.ToInt32(reader["role_id"]),
                    Role = new RoleEntity
                    {
                        Id = Convert.ToInt32(reader["role_id"]),
                        Name = Convert.ToString(reader["role_name"])
                    },
                    State = Convert.ToBoolean(reader["state"])
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
