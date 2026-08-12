using VendorHub.DTOs;
using VendorHub.Models;

namespace VendorHub.Services;

public interface IVendorService
{
    Task<VendorResponseDto> AddVendor(CreateVendorDto dto);

    Task<List<VendorResponseDto>> GetAllVendors();

    Task<VendorResponseDto?> GetVendorById(Guid id);

    Task<VendorResponseDto?> UpdateVendor(Guid id, CreateVendorDto dto);

    Task<bool> DeleteVendor(Guid id);

    Task<VendorResponseDto?> ApproveVendor(Guid id);
}