using FactoryProject.Contracts;
using FactoryProject.Models.IngredientDtos;

namespace FactoryProject.Services;

public class IngredientManager : IIngredientService
{
    private readonly HttpClient _client;
    public IngredientManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }
    public Task<bool> CreateIngredientAsync(CreateIngredientDto createIngredientDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultIngredientDto>> GetAllIngredientsAsync()
    {
        throw new NotImplementedException();
    }
}