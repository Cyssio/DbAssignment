using DbAssignment.Contexts;
using DbAssignment.Entity;

namespace DbAssignment.Repositories;

internal class RoleRepo : Repo<RoleEntity>
{
    public RoleRepo(DataContext context) : base(context)
    {
    }
}


