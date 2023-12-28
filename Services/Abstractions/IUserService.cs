using DataTransferObjects;

namespace Services.Abstractions;

public interface IUserService
{
    public Task<UserDTO> Create(UserDTO user, string password);
    public Task<UserDTO> GetById(int id);
    public Task<UserDTO> GetByUserEmail(string email);

}
