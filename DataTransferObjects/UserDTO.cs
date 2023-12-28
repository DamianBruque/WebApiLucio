

namespace DataTransferObjects;

public class UserDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public RoleDTO Role { get; set; }
    public string? Token { get; set; }
}
