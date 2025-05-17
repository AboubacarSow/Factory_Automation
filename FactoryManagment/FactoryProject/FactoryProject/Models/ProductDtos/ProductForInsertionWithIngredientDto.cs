namespace FactoryProject.Models.ProductDtos;

public class ProductForInsertionWithIngredientDto
{
    public CreateProductDto? product { get; set; }
    public List<int>? ingredientIds{ get; set; }
}