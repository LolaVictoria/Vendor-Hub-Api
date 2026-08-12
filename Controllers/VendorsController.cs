using Microsoft.AspNetCore.Mvc;
using VendorHub.DTOs;
using VendorHub.Services;

namespace VendorHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorsController : ControllerBase
{
    private readonly IVendorService _vendorService;

    public VendorsController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVendors()
    {
        var vendors = await _vendorService.GetAllVendors();

        return Ok(vendors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVendor(
        [FromBody] CreateVendorDto dto)
    {
        var createdVendor = await _vendorService.AddVendor(dto);

        return CreatedAtAction(
            nameof(GetVendorById),
            new { id = createdVendor.Id },
            createdVendor
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVendorById(
        [FromRoute] Guid id)
    {
        var vendor = await _vendorService.GetVendorById(id);

        if (vendor == null)
        {
            return NotFound();
        }

        return Ok(vendor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVendorById(
        [FromRoute] Guid id,
        [FromBody] CreateVendorDto dto)
    {
        var vendor = await _vendorService.UpdateVendor(id, dto);

        if (vendor == null)
        {
            return NotFound();
        }

        return Ok(vendor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVendorById(
        [FromRoute] Guid id)
    {
        var deleted = await _vendorService.DeleteVendor(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPatch("{id}/approve")]
    public async Task<IActionResult> ApproveVendor([FromRoute] Guid id)
    {
        var vendor = await _vendorService.ApproveVendor(id);

        if (vendor == null)
        {
            return NotFound();
        }

        return Ok(vendor);
    }
}