using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Models.UserDtos;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class AccountManager : IAccountService
{
    private readonly HttpClient _httpClient;
    public AccountManager(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("FactoryProjectAPI");
    }

    public async Task<bool> RegisterAysnc(RegisterDto registerDto)
    {
        var content = CreateHttpContent(registerDto);
        var response = await _httpClient.PostAsync("register", content);
        if (!response.IsSuccessStatusCode)
            return false;
        return true;

    }
    private static StringContent CreateHttpContent(object data)
    {
        var json = JsonConvert.SerializeObject(data);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
}
