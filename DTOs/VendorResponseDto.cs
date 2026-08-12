namespace VendorHub.DTOs;

public class VendorResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int NumberOfProducts { get; set; }
    public bool IsApproved { get; set; }
}