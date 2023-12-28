

using DataTransferObjects;

namespace Services.Abstractions;

public interface IJwtService
{
    public string CreateToken(UserDTO user);
}
