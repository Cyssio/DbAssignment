using DbAssignment.Entity;
using DbAssignment.Repositories;

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
        var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == categoryName);
        categoryEntity ??= _categoryRepo.Create(new CategoryEntity { CategoryName = categoryName });

        return categoryEntity;
    }

    public CategoryEntity GetCategoryByCategoryName(string categoryName)
    {
        var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == categoryName);
        return categoryEntity;
    }

    public CategoryEntity GetCategoryByCategoryId(int id) 
    {
        var categoryEntity = _categoryRepo.GetOne(x => x.Id == id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        var categories = _categoryRepo.GetAll();
        return categories;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updatedCategoryEntity = _categoryRepo.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updatedCategoryEntity;
    }

    public bool DeleteCategory(int id) 
    {
        _categoryRepo.Delete(x => x.Id == id);
        return true;
    }
}
