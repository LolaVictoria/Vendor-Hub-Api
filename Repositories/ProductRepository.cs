using Microsoft.EntityFrameworkCore;
using VendorHub.Data;
using VendorHub.Models;

namespace VendorHub.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddProduct(Product product)
    {
        _context.Products.Add(product);
        var vendor = await _context.Vendors
            .FirstOrDefaultAsync(v => v.Id == product.VendorId);

        if (vendor != null)
        {
            vendor.NumberOfProducts++;
        }

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Products
            .Include(p => p.Vendor)
            .ToListAsync();
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        return await _context.Products
            .Include(p => p.Vendor)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        var existingProduct = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == product.Id);

        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;

        await _context.SaveChangesAsync();

        return existingProduct;
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return false;
        }

        var vendor = await _context.Vendors
        .FirstOrDefaultAsync(v => v.Id == product.VendorId);

    if (vendor != null && vendor.NumberOfProducts > 0)
    {
        vendor.NumberOfProducts--;
    }

    _context.Products.Remove(product);

    await _context.SaveChangesAsync();
        return true;
    }
}