using Domain.Entity.Categories;
using Domain.Entity.Products;
using Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class StoreDbContext(DbContextOptions<StoreDbContext> options)
    : IdentityDbContext<User, IdentityRole, string>(options)
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ProductPicture> ProductPictures { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region product table

        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder
            .Entity<Product>()
            .HasMany(p => p.ProductPictures)
            .WithOne(pp => pp.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region product picture table

        modelBuilder.Entity<ProductPicture>().HasKey(pp => pp.PictrueId);
        modelBuilder
            .Entity<ProductPicture>()
            .HasOne(pp => pp.Product)
            .WithMany(p => p.ProductPictures)
            .HasForeignKey(pp => pp.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}