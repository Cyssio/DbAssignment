using DbAssignment.Entity;
using DbAssignment.Repositories;

namespace DbAssignment.Services;

internal class RoleService
{
    private readonly RoleRepo _roleRepo;

    public RoleService(RoleRepo roleRepo) 
    { 
        _roleRepo = roleRepo; 
    }


    public RoleEntity CreateRole(string roleName)
    {
        var RoleEntity = _roleRepo.GetOne(x => x.RoleName == roleName);
        RoleEntity ??= _roleRepo.Create(new RoleEntity { RoleName = roleName });

        return RoleEntity;
    }

    public RoleEntity GetRoleByRoleName(string roleName)
    {
        var RoleEntity = _roleRepo.GetOne(x => x.RoleName == roleName);
        return RoleEntity;
    }

    public RoleEntity GetRoleById(int id)
    {
        var RoleEntity = _roleRepo.GetOne(x => x.Id == id);
        return RoleEntity;
    }

    public IEnumerable<RoleEntity> GetAllRoles()
    {
        var roles = _roleRepo.GetAll();
        return roles;
    }

    public RoleEntity UpdateRole(RoleEntity RoleEntity)
    {
        var updatedRoleEntity = _roleRepo.Update(x => x.Id == RoleEntity.Id, RoleEntity);
        return updatedRoleEntity;
    }

    public bool DeleteRole(int id)
    {
        _roleRepo.Delete(x => x.Id == id);
        return true;
    }
}
