namespace VendorHub.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    // Foreign key
    public Guid VendorId { get; set; }

    // Navigation property
    public Vendor Vendor { get; set; } = null!;
}