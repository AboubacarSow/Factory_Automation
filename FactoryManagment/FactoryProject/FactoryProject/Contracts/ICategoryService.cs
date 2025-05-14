using FactoryProject.Models;
using FactoryProject.Models.CategoryDtos;
namespace FactoryProject.Contracts;

public interface ICategoryService
{
    Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task<bool> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task<bool> DeleteCategoryAsync(int id);
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<ResultCategoryDto> GetCategoryByIdAsync(int id);
}

public interface IDepartmentService
{
    Task<bool> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
    Task<bool> DeleteDepartmentAsync(int departmentId);
    Task<bool> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
}