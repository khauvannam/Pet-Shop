using Domain.Entity.Products;
using Domain.Entity.Users;

namespace Domain.Entity.ProductRelationships;

public class Favorite
{
    public string ProductId { get; set; }
    public Product Product { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int Quanity { get; set; }
}
