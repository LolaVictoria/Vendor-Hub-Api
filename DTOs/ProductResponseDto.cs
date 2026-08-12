namespace VendorHub.DTOs;

public class ProductResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid VendorId { get; set; }
    public string VendorName { get; set; } = string.Empty;
}