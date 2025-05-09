using FactoryProject.Contracts;
using FactoryProject.Models.ProductDtos;

namespace FactoryProject.Services;

public class ProductManager : IProductService
{
    
    public Task CreateProductAsync(CreateProductDto createProductDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
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