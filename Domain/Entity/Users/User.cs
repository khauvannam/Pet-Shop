using Domain.Entity.ProductRelationships;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity.Users;

public sealed class User : IdentityUser<string>
{
    public User()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string? Avatar { get; set; }
    public List<Cart> Carts { get; init; }
    public List<RecentlyView> RecentlyViews { get; init; }
}
