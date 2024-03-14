using Domain.Entity.Categories;
using Domain.Entity.ProductRelationships;

namespace Domain.Entity.Products;

public class Product
{
    public string ProductId = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Description { get; set; }
    public string CategoryId { get; init; }
    public Category Category { get; init; }
    public List<ProductVariation>? ProductVariations { get; init; }
    public List<PromotionProduct>? PromotionProducts { get; set; }
    public List<RecentlyView>? RecentlyViews { get; init; }
}
