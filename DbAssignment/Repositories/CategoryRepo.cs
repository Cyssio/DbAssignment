using DbAssignment.Contexts;
using DbAssignment.Entity;

namespace DbAssignment.Repositories;

internal class CategoryRepo : Repo<CategoryEntity>
{
    public CategoryRepo(DataContext context) : base(context)
    {
    }
}


