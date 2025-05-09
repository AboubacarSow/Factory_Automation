using FactoryProject.Contracts;
using FactoryProject.Services;
using FactoryProject.Infrastructure.Utilities;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FactoryProject.Infrastructure.Extensions;


public static class ServicesExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IAuthService, AuthenticationManager>();
    }
    public static void ConfigureApiSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
        services.AddHttpClient("FactoryApi", (serviceProvider, client) =>
        {
            var tokenContainer = serviceProvider.GetRequiredService<TokenContainer>();
            var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            client.BaseAddress = new Uri(apiSettings?.BaseUrl ?? string.Empty);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenContainer.Token ?? string.Empty);
        });
    }
    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
                options.AccessDeniedPath = "/accessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });
        services.AddAuthorization();
        services.AddHttpContextAccessor();
        services.AddScoped<TokenContainer>();
    }
}