using FactoryProject.Contracts;
using FactoryProject.Services;

namespace FactoryProject.DependencyInjection;

public static class DIContaier
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IAuthService, AuthenticationManager>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}