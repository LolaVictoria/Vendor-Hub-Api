using Microsoft.EntityFrameworkCore;
using VendorHub.Models;

namespace VendorHub.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Product> Products { get; set; }
}