using VendorHub.DTOs;
using VendorHub.Models;

namespace VendorHub.Services;

public interface IProductService
{
    Task<ProductResponseDto?> AddProduct(CreateProductDto dto);

    Task<List<ProductResponseDto>> GetAllProducts();

    Task<ProductResponseDto?> GetProductById(Guid id);

    Task<ProductResponseDto?> UpdateProduct(Guid id, CreateProductDto dto);

    Task<bool> DeleteProduct(Guid id);
}