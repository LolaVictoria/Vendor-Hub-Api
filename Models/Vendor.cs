namespace VendorHub.Models;


public class Vendor
{
    public Guid Id{set; get;}
    public required string Name{set; get;}
    public required string Email{set; get;}
    public int NumberOfProducts{set; get;}
    public bool IsApproved{set; get;}
    public List<Product> Products { get; set; } = new();

}