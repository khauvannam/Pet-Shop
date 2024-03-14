using Domain.Entity.ProductRelationships;

namespace Domain.Entity.Products;

public class ProductVariation
{
    public string VariationId { get; init; } = Guid.NewGuid().ToString();
    public Product Product { get; init; }
    public string ProductId { get; init; }

    public float Price { get; set; }
    public string Size { get; set; }
    public int QuantityInStock { get; set; }
    public string UrlImage { get; set; }
    public List<Cart>? Carts { get; init; }
}
