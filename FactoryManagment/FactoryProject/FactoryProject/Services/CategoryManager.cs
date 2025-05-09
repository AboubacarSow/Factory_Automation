using FactoryProject.Contracts;
using FactoryProject.Models.CategoryDtos;

namespace FactoryProject.Services;

public class CategoryManager : ICategoryService
{
    public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultCategoryDto> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }
}