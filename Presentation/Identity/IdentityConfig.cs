using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public static class IdentityConfig
{
    public static void CorsConfig(this CorsOptions options)
    {
        options.AddDefaultPolicy(
            builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        );
    }

    public static void IdentityOptions(this IdentityOptions options)
    {
        options.Password = new PasswordOptions
        {
            RequireLowercase = false,
            RequireUppercase = false,
            RequireDigit = false,
            RequireNonAlphanumeric = false
        };
        options.User = new UserOptions()
        {
            AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+",
            RequireUniqueEmail = true,
        };
        options.Lockout = new LockoutOptions() { AllowedForNewUsers = true };
    }
}
