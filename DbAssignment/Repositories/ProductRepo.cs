using DbAssignment.Contexts;
using DbAssignment.Entity;

namespace DbAssignment.Repositories;

internal class ProductRepo : Repo<ProductEntity>
{
    public ProductRepo(DataContext context) : base(context)
    {
    }
}


