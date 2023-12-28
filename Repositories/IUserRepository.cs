

using Models;

namespace Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetByEmail(string email);
    Task<UserEntity> Create(UserEntity user);

}
