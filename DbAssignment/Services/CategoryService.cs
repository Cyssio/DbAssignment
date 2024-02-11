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
        try
        {
            var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == categoryName);
            return categoryEntity;
        } 
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
        
    }

    public CategoryEntity GetCategoryByCategoryId(int id) 
    {
        try
        {
            var categoryEntity = _categoryRepo.GetOne(x => x.Id == id);
            return categoryEntity;
        } 
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
        
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        try
        {
            var categories = _categoryRepo.GetAll();
            return categories;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        try
        {
            var updatedCategoryEntity = _categoryRepo.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            return updatedCategoryEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteCategory(int id) 
    {
        try
        {
            _categoryRepo.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
