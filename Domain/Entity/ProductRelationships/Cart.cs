using Domain.Entity.Products;
using Domain.Entity.Users;

namespace Domain.Entity.ProductRelationships;

public class Cart
{
    public string CartId = Guid.NewGuid().ToString();
    public int Quantity { get; set; } = 1;
    public DateTime CreatedAt { get; set; }
    public string ProductVariationId { get; init; }
    public ProductVariation ProductVariation { get; init; }
    public string UserId { get; init; }
    public User User { get; init; }
}
