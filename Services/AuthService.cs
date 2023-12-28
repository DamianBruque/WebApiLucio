
using DataTransferObjects;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repositories;
using Services.Abstractions;
using Utilities;
using Utilities.Exceptions;

namespace Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;
    private readonly IRoleRepository roleRepository;

    public AuthService(IUserRepository userRepository,IRoleRepository roleRepository)
    {
        this.userRepository = userRepository;
        this.roleRepository = roleRepository;
    }

    public Task<UserDTO> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) throw new InvalidFieldsException();
        Task<UserEntity> user = userRepository.GetByEmail(email);
        if (user != null) 
        { 
            // comparamos la password con bcrypt
            if (BCrypt.Net.BCrypt.Verify(password, user.Result.Password))
            {
                // si la password es correcta, retornamos el usuario
                return Task.FromResult(Utilitie.Map<UserDTO, UserEntity>(user.Result));
            }
            else
            {
                throw new InvalidPasswordException();
            }
        }
        else
        {
            throw new UserNotFoundException();
        }
    }
    
    public async Task<UserDTO> Register(UserDTO user, string password)
    {
        if (user.Email.IsNullOrEmpty() || password.IsNullOrEmpty() || user.Role.Name.IsNullOrEmpty()) throw new InvalidFieldsException();
        string encriptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var userEntity = await userRepository.GetByEmail(user.Email);
        if (userEntity == null)
        {
            userEntity = Utilitie.Map<UserEntity, UserDTO>(user);
            userEntity.Password = encriptedPassword;
            var userRole = await roleRepository.GetByName("user");
            if (userRole == null) throw new RoleNotFoundException();
            userEntity.RoleId = userRole.Id;
            userEntity.State = true;
            userEntity = await userRepository.Create(userEntity);
            return Utilitie.Map<UserDTO, UserEntity>(userEntity);
        }
        else
        {
            throw new UserAlreadyExistsException();
        }
    }
}
