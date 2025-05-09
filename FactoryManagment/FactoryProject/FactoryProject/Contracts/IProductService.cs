using FactoryProject.Models.ProductDtos;    

namespace FactoryProject.Contracts;
public interface IProductService
{
    public Task CreateProductAsync(CreateProductDto createProductDto);
    public Task UpdateProductAsync(UpdateProductDto updateProductDto);
    public Task DeleteProductAsync(int id);
    public Task<List<ResultProductDto>> GetAllProductsAsync();
    public Task<ResultProductDto> GetProductByCateogryIdAsync(int id);
    public Task<ResultProductDto> GetProductByIdAsync(int id);
}