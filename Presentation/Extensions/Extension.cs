using Application.Behaviors;
using Application.Commands.Accounts;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.JwtHandlers;
using Application.Mapping;
using Application.UserContexts;
using Application.Validators;
using Domain.Common.Keys;
using Domain.Entities.Users;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUserContext, UserContext>();

        services.AddHttpContextAccessor();
        services.AddSignalR();
        services.AddAutoMapper(typeof(UserProfile));
        services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(Key.ConnectionString));
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Register).Assembly);
            cfg.AddOpenBehavior(typeof(RequestLoggingPipeline<,>));
        });
        services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
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

    public static void AddToModelState(this ValidationResult result, ModelStateDictionary model)
    {
        foreach (var error in result.Errors)
        {
            model.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}
