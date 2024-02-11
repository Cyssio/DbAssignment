using DbAssignment.Entity;
using DbAssignment.Repositories;
using System.Diagnostics;

namespace DbAssignment.Services;

internal class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly CategoryService _categorySercive;

    public ProductService(ProductRepo productRepo, CategoryService categorySercive)
    {
        _productRepo = productRepo;
        _categorySercive = categorySercive;
    }



    public ProductEntity CreateProduct();

    public ProductEntity GetProductById(int id)
    {
        try
        {
            var ProductEntity = _productRepo.GetOne(x => x.Id == id);
            return ProductEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<ProductEntity> GetAllProducts()
    {
        try
        {
            var products = _productRepo.GetAll();
            return products;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public ProductEntity UpdateProduct(ProductEntity ProductEntity)
    {
        try
        {
            var updatedProductEntity = _productRepo.Update(x => x.Id == ProductEntity.Id, ProductEntity);
            return updatedProductEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteProduct(int id)
    {
        try
        {
            _productRepo.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
