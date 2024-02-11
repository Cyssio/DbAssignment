using DbAssignment.Dtos;
using DbAssignment.Entity;
using DbAssignment.Repositories;
using System.Diagnostics;

namespace DbAssignment.Services;

internal class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly CategoryService _categoryService;

    public ProductService(ProductRepo productRepo, CategoryService categoryService)
    {
        _productRepo = productRepo;
        _categoryService = categoryService;
    }



    public ProductEntity CreateProduct(CreateProductDto _createProduct)
    {
        try
        {
            var categoryEntity = _categoryService.CreateCategory(_createProduct.CategoryName);

            var productEntity = new ProductEntity
            {
                Title = _createProduct.Title,
                Price = _createProduct.Price,
                CategoryId = categoryEntity.Id,
            };

            productEntity = _productRepo.Create(productEntity);
            return productEntity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ProductEntity GetProductById(int id)
    {
        try
        {
            var productEntity = _productRepo.GetOne(x => x.Id == id);
            return productEntity;
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

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        try
        {
            var updatedProductEntity = _productRepo.Update(x => x.Id == productEntity.Id, productEntity);
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
