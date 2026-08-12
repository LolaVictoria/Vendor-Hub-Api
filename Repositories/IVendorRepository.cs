using VendorHub.Models;

namespace VendorHub.Repositories;

public interface IVendorRepository
{
    Task<Vendor> AddVendor(Vendor vendor);

    Task<List<Vendor>> GetAllVendors();

    Task<Vendor?> GetVendorById(Guid id);

    Task<Vendor?> UpdateVendor(Vendor vendor);

    Task<bool> DeleteVendor(Guid id);
}