using DbAssignment.Entity;
using DbAssignment.Repositories;
using System.Diagnostics;

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
        try
        {
            var RoleEntity = _roleRepo.GetOne(x => x.RoleName == roleName);
            RoleEntity ??= _roleRepo.Create(new RoleEntity { RoleName = roleName });

            return RoleEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public RoleEntity GetRoleByRoleName(string roleName)
    {
        try
        {
            var RoleEntity = _roleRepo.GetOne(x => x.RoleName == roleName);
            return RoleEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public RoleEntity GetRoleById(int id)
    {
        try
        {
            var RoleEntity = _roleRepo.GetOne(x => x.Id == id);
            return RoleEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<RoleEntity> GetAllRoles()
    {
        try
        {
            var roles = _roleRepo.GetAll();
            return roles;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public RoleEntity UpdateRole(RoleEntity RoleEntity)
    {
        try
        {
            var updatedRoleEntity = _roleRepo.Update(x => x.Id == RoleEntity.Id, RoleEntity);
            return updatedRoleEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteRole(int id)
    {
        try
        {
            _roleRepo.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
