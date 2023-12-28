

using DataTransferObjects;

namespace Services.Abstractions;

public interface IAuthService
{
    public Task<UserDTO> Login(string email, string password);
    public Task<UserDTO> Register(UserDTO user, string password);

}
