using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Users;

public sealed class User : IdentityUser<string>
{
    public User() => Id = Guid.NewGuid().ToString();

    public string? Avatar { get; set; }
}
