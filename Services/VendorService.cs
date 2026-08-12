using VendorHub.DTOs;
using VendorHub.Models;
using VendorHub.Repositories;

namespace VendorHub.Services;

public class VendorService : IVendorService
{
    private readonly IVendorRepository _vendorRepository;

    public VendorService(IVendorRepository vendorRepository)
    {
        _vendorRepository = vendorRepository;
    }

    public async Task<VendorResponseDto> AddVendor(CreateVendorDto dto)
    {
        var vendor = new Vendor
        {
            Name = dto.Name,
            Email = dto.Email,
            NumberOfProducts = 0,
            IsApproved = false
        };

        var createdVendor = await _vendorRepository.AddVendor(vendor);

         return new VendorResponseDto
        {
            Id = createdVendor.Id,
            Name = createdVendor.Name,
            Email = createdVendor.Email,
            NumberOfProducts = createdVendor.NumberOfProducts,
            IsApproved = createdVendor.IsApproved
        };
    }

    public async Task<List<VendorResponseDto>> GetAllVendors()
    {
         var vendors = await _vendorRepository.GetAllVendors();

        return vendors.Select(vendor => new VendorResponseDto
        {
            Id = vendor.Id,
            Name = vendor.Name,
            Email = vendor.Email,
            NumberOfProducts = vendor.NumberOfProducts,
            IsApproved = vendor.IsApproved
        }).ToList();
    }

    public async Task<VendorResponseDto?> GetVendorById(Guid id)
    {
        var vendor = await _vendorRepository.GetVendorById(id);

        if (vendor == null)
        {
            return null;
        }

        return new VendorResponseDto
        {
            Id = vendor.Id,
            Name = vendor.Name,
            Email = vendor.Email,
            NumberOfProducts = vendor.NumberOfProducts,
            IsApproved = vendor.IsApproved
        };
    }

    public async Task<VendorResponseDto?> UpdateVendor(Guid id, CreateVendorDto dto)
    {
        var vendor = new Vendor
        {
            Id = id,
            Name = dto.Name,
            Email = dto.Email
        };
        var updatedVendor = await _vendorRepository.UpdateVendor(vendor);

        if (updatedVendor == null)
        {
            return null;
        }

        return new VendorResponseDto
        {
            Id = updatedVendor.Id,
            Name = updatedVendor.Name,
            Email = updatedVendor.Email,
            NumberOfProducts = updatedVendor.NumberOfProducts,
            IsApproved = updatedVendor.IsApproved
        };
    }

    public async Task<bool> DeleteVendor(Guid id)
    {
        return await _vendorRepository.DeleteVendor(id);
    }

    public async Task<VendorResponseDto?> ApproveVendor(Guid id)
    {
        var vendor = await _vendorRepository.GetVendorById(id);

        if (vendor == null)
        {
            return null;
        }

        vendor.IsApproved = true;

        var updatedVendor = await _vendorRepository.UpdateVendor(vendor);

        if (updatedVendor == null)
        {
            return null;
        }

        return new VendorResponseDto
        {
            Id = updatedVendor.Id,
            Name = updatedVendor.Name,
            Email = updatedVendor.Email,
            NumberOfProducts = updatedVendor.NumberOfProducts,
            IsApproved = updatedVendor.IsApproved
        };
    }
}