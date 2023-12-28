

using DataTransferObjects;

namespace Services.Abstractions;

public interface IRoleService
{
    Task<IEnumerable<RoleDTO>> GetAll();
}
