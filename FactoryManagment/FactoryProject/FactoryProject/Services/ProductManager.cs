using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Infrastructure.Utilities;
using FactoryProject.Models;
using FactoryProject.Models.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class ProductManager : IProductService
{
    private readonly HttpClient _client;
    public ProductManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }
    public async Task<bool> CreateProductAsync(ProductForInsertionWithIngredientDto createProductDto)
    {
        var jsonData = JsonConvert.SerializeObject(createProductDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var request = await _client.PostAsync("product/add",content);
        return request.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var request = await _client.DeleteAsync($"product/delete?productId={id}");
        return request.IsSuccessStatusCode;
    }

    public async Task<PagedList<ResultProductDto>> GetAllProductsWithPaginationAsync(RequestParameters requestParameters)
    {
        var source = await GetAllProductsAsync();
        var items = PagedList<ResultProductDto>.ToPagedList(source,requestParameters.PageNumber,
        requestParameters.PageSize);
        return items;
    }
    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var response = await _client.GetAsync("product/all");
        if (!response.IsSuccessStatusCode)
            throw new Exception("An error occured while fetching data from api");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return [];
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData)!;
    }
    public async Task<List<ResultProductDto>> GetProductByCateogryIdAsync(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"product?categoryId={id}");
        var response = await _client.SendAsync(request);
        var jsonData = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        return products!;
    }

    public async Task<ResultProductDto> GetProductByIdAsync(int id)
    {
        var product = await GetAllProductsAsync();
        return product.FirstOrDefault(p=>p.Id.Equals(id))!;
    }

    public async Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var jsonData = JsonConvert.SerializeObject(updateProductDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var request = await _client.PostAsync("product/update",content);
        return request.IsSuccessStatusCode;
    }

   
}