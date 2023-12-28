using DataTransferObjects;
using Models;
using Repositories;
using Services.Abstractions;
using System.Data;
using Utilities;

namespace Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository roleRepository;
    public RoleService(IRoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public Task<IEnumerable<RoleDTO>> GetAll()
    {
        List<RoleDTO> roles = new List<RoleDTO>();
        List<RoleEntity> rolesEntities = roleRepository.GetAll().Result.ToList();
        rolesEntities.ForEach(role => roles.Add(Utilitie.Map<RoleDTO, RoleEntity>(role)));
        return Task.FromResult(roles.AsEnumerable());

    }
}
