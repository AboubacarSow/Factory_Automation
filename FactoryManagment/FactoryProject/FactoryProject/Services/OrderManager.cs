using System.Text;
using FactoryProject.Contracts;
using FactoryProject.Models;
using FactoryProject.Models.OrderDtos;
using Newtonsoft.Json;

namespace FactoryProject.Services;

public class OrderManager: IOrderService
{
    private readonly HttpClient _client;
    public OrderManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("FactoryApi");
    }

    public async Task<bool> CreateOrderAsync(CreateOrderDto createorderdto)
    {
        var jsonData = JsonConvert.SerializeObject(createorderdto);
        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("order/add", content: payload);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ResultOrderDto>> GetAllOrderAsync()
    {
        var response = await _client.GetAsync("order/get");
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData)!;
        
    }

    public async Task<ResultOrderDto> GetOrderByIdAsync(int orderId)
    {
        var orders = await GetAllOrderAsync();
        return orders.FirstOrDefault(or => or.id == orderId)!;
    }

    public async Task<List<ResultOrderDto>> GetOrdersByUserAsync()
    {
        var response = await _client.GetAsync("order/getByUser");
        if (!response.IsSuccessStatusCode) return [];
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData)!;
    }

    public async Task<List<PendingOrderDto>> GetPendingOrdersAsync()
    {
        var response = await _client.GetAsync("order/getPendingOrders");
        if (!response.IsSuccessStatusCode)
            return [];
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<PendingOrderDto>>(jsonData)!;
    }

    public async Task<List<TopProductDto>> GetTopProductsAsync()
    {
        var response = await _client.GetAsync("order/getTopProducts");
        if (!response.IsSuccessStatusCode) return [];
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<TopProductDto>>(jsonData)!;
    }

    public async Task<double> GetTotalRevenueAsync()
    {
        var response = await _client.GetAsync("order/revenue/delivered");
        if(!response.IsSuccessStatusCode) return 0;
        var jsonData= await response.Content.ReadAsStringAsync();
        var resultRevenu= JsonConvert.DeserializeObject<RevenueResultDto>(jsonData)!;
        return resultRevenu.Revenue;
    }

    public async Task<bool> UpdateOrderAsync(UpdateOrderDto updateorderdto)
    {
        var jsonData = JsonConvert.SerializeObject(updateorderdto);
        var payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("order/update", content: payload);
        return response.IsSuccessStatusCode;
    }
}