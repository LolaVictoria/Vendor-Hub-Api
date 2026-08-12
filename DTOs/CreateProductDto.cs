using System.ComponentModel.DataAnnotations;

namespace VendorHub.DTOs;

public class CreateProductDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public Guid VendorId { get; set; }
}