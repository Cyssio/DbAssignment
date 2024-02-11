using DbAssignment.Contexts;
using DbAssignment.Entity;

namespace DbAssignment.Repositories;

internal class AddressRepo : Repo<AddressEntity>
{
    public AddressRepo(DataContext context) : base(context)
    {
    }
}
