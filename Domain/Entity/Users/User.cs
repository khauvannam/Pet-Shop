using Microsoft.AspNetCore.Identity;

namespace Domain.Entity.Users;

public sealed class User : IdentityUser<string>
{
    public User()
    {
        Id = Guid.NewGuid().ToString();
    }
}
