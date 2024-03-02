using Domain.Entity.Categories;
using Domain.Entity.Products;
using Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class StoreDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ProductPictures> PicturesEnumerable { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region product table

        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder
            .Entity<Product>()
            .HasMany(p => p.ProductPicturesList)
            .WithOne(pp => pp.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region product picture table

        modelBuilder.Entity<ProductPictures>().HasKey(pp => pp.PictrueId);
        modelBuilder
            .Entity<ProductPictures>()
            .HasOne(pp => pp.Product)
            .WithMany(p => p.ProductPicturesList)
            .HasForeignKey(pp => pp.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}
