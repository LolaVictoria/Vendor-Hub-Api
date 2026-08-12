using Microsoft.EntityFrameworkCore;
using VendorHub.Data;
using VendorHub.Models;

namespace VendorHub.Repositories;

public class VendorRepository : IVendorRepository
{
    private readonly AppDbContext _context;

    public VendorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Vendor> AddVendor(Vendor vendor)
    {
        _context.Vendors.Add(vendor);

        await _context.SaveChangesAsync();

        return vendor;
    }

    public async Task<List<Vendor>> GetAllVendors()
    {
        return await _context.Vendors.ToListAsync();
    }

    public async Task<Vendor?> GetVendorById(Guid id)
    {
        return await _context.Vendors
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Vendor?> UpdateVendor(Vendor vendor)
    {
        var existingVendor = await _context.Vendors
            .FirstOrDefaultAsync(v => v.Id == vendor.Id);

        if (existingVendor == null)
        {
            return null;
        }

        existingVendor.Name = vendor.Name;
        existingVendor.Email = vendor.Email;

        await _context.SaveChangesAsync();

        return existingVendor;
    }

    public async Task<bool> DeleteVendor(Guid id)
    {
        var vendor = await _context.Vendors
            .FirstOrDefaultAsync(v => v.Id == id);

        if (vendor == null)
        {
            return false;
        }

        _context.Vendors.Remove(vendor);

        await _context.SaveChangesAsync();

        return true;
    }
}