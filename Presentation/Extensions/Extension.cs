using Application.Abstraction;
using Application.Abstraction.Behaviors;
using Application.Abstraction.Repository;
using Application.JwtHandlers;
using Application.Mapper;
using Domain.Entity.Keys;
using Domain.Entity.Users;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions.Identity;

namespace Presentation.Extensions;

public static class Extension
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddTransient(typeof(JwtHandler));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddHttpContextAccessor();
        services.AddSignalR();
        services.AddAutoMapper(typeof(UserProfile));
        services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(Key.ConnectionString));
    }

    public static void AddIdentityConfig(this IServiceCollection services)
    {
        const string jwtSecret = Key.JwtSecret;

        services.Configure<IdentityOptions>(opt => opt.IdentityOptions());

        services.AddCors(opt => opt.CorsConfig());

        services
            .AddIdentity<User, IdentityRole>(opt => opt.SignIn.RequireConfirmedAccount = false)
            .AddSignInManager()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<StoreDbContext>();

        services
            .AddAuthentication(opt => opt.AuthOptionsConfig())
            .AddJwtBearer(opt => opt.BearerOptionsConfig(jwtSecret));

        services.AddAuthorization(opt => opt.AuthorizationConfig());
    }
}
