using FactoryProject.Models.CategoryDtos;

namespace FactoryProject.Models.ProductDtos;

 public class ResultProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public ResultCategoryDto Category { get; set; }
}
