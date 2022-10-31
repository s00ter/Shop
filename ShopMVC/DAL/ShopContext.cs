using DAL.Entities;
using DAL.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ShopContext : IdentityDbContext<IdentityUser>
{
    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Shop> Shops { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Seed();
        
        base.OnModelCreating(builder);
    }
}