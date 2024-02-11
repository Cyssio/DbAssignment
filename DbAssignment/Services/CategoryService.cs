using DbAssignment.Entity;
using DbAssignment.Repositories;
using System.Diagnostics;

namespace DbAssignment.Services;

internal class CategoryService
{
    private readonly CategoryRepo _categoryRepo;

    public CategoryService(CategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }



    public CategoryEntity CreateCategory(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == categoryName);
            categoryEntity ??= _categoryRepo.Create(new CategoryEntity { CategoryName = categoryName });

            return categoryEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CategoryEntity GetCategoryByCategoryName(string categoryName) 
    {
        var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == categoryName);
        return categoryEntity;
    }
}
