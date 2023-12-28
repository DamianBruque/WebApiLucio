

using Models;

namespace Repositories
{
    public interface IRoleRepository
    {
        Task<RoleEntity> GetByName(string name);
        Task<IEnumerable<RoleEntity>> GetAll();
    }
}
