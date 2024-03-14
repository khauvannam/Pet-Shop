using Application.Abstraction.Extensions;
using Domain.Entity.Categories;
using Domain.Entity.ProductRelationships;
using Domain.Entity.Products;
using Domain.Entity.Promotions;
using Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class StoreDbContext(DbContextOptions<StoreDbContext> options)
    : IdentityDbContext<User, IdentityRole, string>(options)
{
    public DbSet<Promotion>? Promotions { get; init; }
    public DbSet<Product>? Products { get; init; }
    public DbSet<Category>? Categories { get; init; }
    public DbSet<ProductVariation>? ProductVariations { get; init; }
    public DbSet<Cart>? Carts { get; init; }
    public DbSet<RecentlyView>? RecentlyViews { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.DataBaseConfig();
    }
}
