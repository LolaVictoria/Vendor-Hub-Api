using VendorHub.DTOs;
using VendorHub.Models;
using VendorHub.Repositories;

namespace VendorHub.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IVendorRepository _vendorRepository;

    public ProductService(
        IProductRepository productRepository,
        IVendorRepository vendorRepository)
    {
        _productRepository = productRepository;
        _vendorRepository = vendorRepository;
    }

    public async Task<ProductResponseDto?> AddProduct(CreateProductDto dto)
    {
        var vendor = await _vendorRepository.GetVendorById(dto.VendorId);

        if (vendor == null)
        {
            return null;
        }

        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            VendorId = dto.VendorId
        };

        var createdProduct = await _productRepository.AddProduct(product);

        return new ProductResponseDto
        {
            Id = createdProduct.Id,
            Name = createdProduct.Name,
            Price = createdProduct.Price,
            VendorId = createdProduct.VendorId,
            VendorName = vendor.Name
        };
    }

    public async Task<List<ProductResponseDto>> GetAllProducts()
    {
        var products = await _productRepository.GetAllProducts();

        return products.Select(product => new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            VendorId = product.VendorId,
            VendorName = product.Vendor?.Name ?? string.Empty
        }).ToList();
    }

    public async Task<ProductResponseDto?> GetProductById(Guid id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product == null)
        {
            return null;
        }

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            VendorId = product.VendorId,
            VendorName = product.Vendor?.Name ?? string.Empty
        };
    }

    public async Task<ProductResponseDto?> UpdateProduct(
        Guid id,
        CreateProductDto dto)
    {
        var existingProduct = await _productRepository.GetProductById(id);

        if (existingProduct == null)
        {
            return null;
        }

        var product = new Product
        {
            Id = id,
            Name = dto.Name,
            Price = dto.Price,
            VendorId = existingProduct.VendorId
        };

        var updatedProduct =
            await _productRepository.UpdateProduct(product);

        if (updatedProduct == null)
        {
            return null;
        }

        return new ProductResponseDto
        {
            Id = updatedProduct.Id,
            Name = updatedProduct.Name,
            Price = updatedProduct.Price,
            VendorId = updatedProduct.VendorId,
            VendorName = existingProduct.Vendor?.Name ?? string.Empty
        };
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        return await _productRepository.DeleteProduct(id);
    }
}