using Domain.Entity.Products;
using Domain.Entity.Users;

namespace Domain.Entity.ProductRelationships;

public class RecentlyView
{
    public string RecentlyViewId = Guid.NewGuid().ToString();
    public string ProductId { get; init; }
    public Product Product { get; init; }
    public string UserId { get; init; }
    public User User { get; init; }
    public DateTime ViewedAt { get; init; }
}
