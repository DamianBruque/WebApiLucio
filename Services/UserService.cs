using DataTransferObjects;
using Models;
using Repositories;
using Services.Abstractions;
using Utilities;

namespace Services;

public class UserService : IUserService
{
    
    private readonly IUserRepository repository;
    public UserService(IUserRepository userRepository)
    {
        repository = userRepository;
    }

    public async Task<UserDTO> Create(UserDTO user,string password)
    {
        var userEntity = Utilitie.Map<UserEntity, UserDTO>(user);
        userEntity.Password = BCrypt.Net.BCrypt.HashPassword(password);
        userEntity.State = true;
        var result = await repository.Create(userEntity);
        return Utilitie.Map<UserDTO, UserEntity>(result);
    }

    public Task<UserDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetByUserEmail(string email)
    {
        throw new NotImplementedException();
    }
}
