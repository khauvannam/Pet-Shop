using Domain.Entity.Products;
using Domain.Entity.Promotions;

namespace Domain.Entity.ProductRelationships;

public class PromotionProduct
{
   public string ProductId { get; init; }
   public Product Product {get; init; } 
   public string PromotionId { get; init; }
   public Promotion Promotion { get; init; }
}