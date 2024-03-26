using Application.Extensions;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Promotions;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class StoreDbContext(DbContextOptions<StoreDbContext> options)
    : IdentityDbContext<User, IdentityRole, string>(options)
{
    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Promotion> Promotions { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderLine> OrderLines { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.DataBaseConfig();
    }
}
