using System.Security.Claims;
using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Infrastructure.Extensions;
using FactoryProject.Infrastructure.Utilities;
using FactoryProject.Models.UserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class AuthenticationManager(IHttpClientFactory httpClientFactory,
                                   IHttpContextAccessor httpContextAccessor,
                                   TokenContainer tokenContainer) : IAuthService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("FactoryProjectAPI");
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly TokenContainer _tokenContainer = tokenContainer;



    public async Task<bool> LoginAsync(LoginModel loginModel)
    {
        var content = CreateHttpContent(loginModel);
        var response = await _httpClient.PostAsync("login", content);
        if (!response.IsSuccessStatusCode)
            return false;
        var token = await response.Content.ReadAsStringAsync();
        var tokenContainer = JsonConvert.DeserializeObject<TokenContainer>(token);
        if (String.IsNullOrEmpty(tokenContainer?.Token))
            return false;
        _tokenContainer.Token = tokenContainer.Token;
        await AuthenticateAsync(_tokenContainer);
        return true;

    }

    private async Task AuthenticateAsync(TokenContainer tokenContainer)
    {
        var claims = JwtParser.ParseClaimsFromJwt(tokenContainer.Token);
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var expiration = JwtParser.GetExpirationDateFromClaims(claims!);
        var principal = new ClaimsPrincipal(identity);
        var context = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is not available.");
        await context.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IsPersistent = false,
                AllowRefresh = true,
                ExpiresUtc = expiration,
            }
        );
    }

    private static StringContent CreateHttpContent(object data)
    {
        var json = JsonConvert.SerializeObject(data);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
    public Task LogoutAsync()
    {
       _tokenContainer.Token = string.Empty;
        var context = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is not available.");
        return context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
