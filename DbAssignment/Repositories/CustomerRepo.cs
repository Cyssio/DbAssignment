using DbAssignment.Contexts;
using DbAssignment.Entity;

namespace DbAssignment.Repositories;

internal class CustomerRepo : Repo<CustomerEntity>
{
    public CustomerRepo(DataContext context) : base(context)
    {
    }
}


