using Application.Abstraction;
using Infrastructure.Identity;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;

namespace Presentation.Extensions;

public static class Extension
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddHttpContextAccessor();
        services.AddSignalR();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    }

    public static void AddIdentityConfig(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(opt => opt.IdentityOptions());
        services.AddCors(opt => opt.CorsConfig());
    }
}
