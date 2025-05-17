using FactoryProject.Infrastructure.Utilities;
using FactoryProject.Models;
using FactoryProject.Models.ProductDtos;    

namespace FactoryProject.Contracts;

public interface IProductService
{
     Task<bool> CreateProductAsync(ProductForInsertionWithIngredientDto createProductDto);
     Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto);
     Task<bool> DeleteProductAsync(int id);
     Task<List<ResultProductDto>> GetAllProductsAsync();
     Task<PagedList<ResultProductDto>> GetAllProductsWithPaginationAsync(RequestParameters requestParameter);
     Task<List<ResultProductDto>> GetProductByCateogryIdAsync(int id);
     Task<ResultProductDto> GetProductByIdAsync(int id);
    
}