using VendorHub.Models;

namespace VendorHub.Repositories;

public interface IProductRepository
{
    Task<Product> AddProduct(Product product);

    Task<List<Product>> GetAllProducts();

    Task<Product?> GetProductById(Guid id);

    Task<Product?> UpdateProduct(Product product);

    Task<bool> DeleteProduct(Guid id);
}