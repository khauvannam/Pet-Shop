using Domain.Entity.Roles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Presentation.Extensions.Identity;

public static class IdentityConfig
{
    public static void AuthorizationConfig(this AuthorizationOptions options)
    {
        options.AddPolicy(
            "Basic",
            policy =>
                policy.RequireClaim(nameof(Role), Role.BasicUser, Role.PremiumUser, Role.Admin)
        );
        options.AddPolicy(
            "Premium",
            policy => policy.RequireClaim(nameof(Role), Role.PremiumUser, Role.Admin)
        );
        options.AddPolicy("Admin", policy => policy.RequireClaim(nameof(Role), Role.Admin));
    }

    public static void AuthOptionsConfig(this AuthenticationOptions options)
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }

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
