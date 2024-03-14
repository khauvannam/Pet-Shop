using Domain.Entity.Categories;
using Domain.Entity.ProductRelationships;
using Domain.Entity.Products;
using Domain.Entity.Promotions;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction.Extensions;

public static class ModelBuilderExtensions
{
    public static void DataBaseConfig(this ModelBuilder modelBuilder)
    {
        #region product table

        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

        modelBuilder
            .Entity<Product>()
            .HasMany(p => p.ProductVariations)
            .WithOne(pv => pv.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Product>()
            .HasMany(p => p.PromotionProducts)
            .WithOne(pp => pp.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region product_variation table

        modelBuilder.Entity<ProductVariation>().HasKey(pv => pv.VariationId);

        modelBuilder
            .Entity<ProductVariation>()
            .HasOne(pv => pv.Product)
            .WithMany(p => p.ProductVariations)
            .HasForeignKey(pv => pv.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Cart>()
            .HasOne(c => c.ProductVariation)
            .WithMany(p => p.Carts)
            .HasForeignKey(c => c.ProductVariationId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region cart table

        modelBuilder.Entity<Cart>().HasKey(c => c.CartId);

        modelBuilder
            .Entity<Cart>()
            .HasOne(c => c.User)
            .WithMany(u => u.Carts)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Cart>()
            .HasOne(c => c.ProductVariation)
            .WithMany(pv => pv.Carts)
            .HasForeignKey(c => c.ProductVariationId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region recently_view table

        modelBuilder.Entity<RecentlyView>().HasKey(r => r.RecentlyViewId);

        modelBuilder
            .Entity<RecentlyView>()
            .HasOne(r => r.Product)
            .WithMany(p => p.RecentlyViews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<RecentlyView>()
            .HasOne(r => r.User)
            .WithMany(p => p.RecentlyViews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region category table

        modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

        modelBuilder
            .Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region promotion table

        modelBuilder.Entity<Promotion>().HasKey(p => p.PromotionId);

        modelBuilder
            .Entity<Promotion>()
            .HasMany(p => p.PromotionProducts)
            .WithOne(pp => pp.Promotion)
            .HasForeignKey(p => p.PromotionId);

        #endregion

        #region promotion_product table

        modelBuilder.Entity<PromotionProduct>().HasKey(pp => new { pp.ProductId, pp.PromotionId });

        #endregion
    }
}
