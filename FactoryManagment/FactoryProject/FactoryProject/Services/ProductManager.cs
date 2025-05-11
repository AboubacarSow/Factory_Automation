using FactoryProject.Contracts;
using FactoryProject.Infrastructure.Utilities;
using FactoryProject.Models.ProductDtos;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class ProductManager : IProductService
{
    private readonly HttpClient _client;
    public ProductManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }
    public Task CreateProductAsync(CreateProductDto createProductDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList<ResultProductDto>> GetAllProductsAsync(RequestParameters requestParameters)
    {
        var response =await  _client.GetAsync("/product/all");
        if (!response.IsSuccessStatusCode)
            throw new Exception("An error occured while feching data from api");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;
        var jsonData = await response.Content.ReadAsStringAsync();
        var source = JsonConvert.DeserializeObject <List<ResultProductDto>>(jsonData);
        var items = PagedList<ResultProductDto>.ToPagedList(source,requestParameters.PageNumber,
        requestParameters.PageSize);
        return 
    }

    public Task<ResultProductDto> GetProductByCateogryIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultProductDto> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        throw new NotImplementedException();
    }
}