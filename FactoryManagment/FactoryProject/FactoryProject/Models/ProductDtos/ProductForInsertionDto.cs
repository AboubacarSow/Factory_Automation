using System.ComponentModel.DataAnnotations;

namespace FactoryProject.Models.ProductDtos;

public class ProductForInsertionDto
{
    [Required(ErrorMessage = "Name field is required")]
    [MinLength(4, ErrorMessage = "Name of product must be at least 4 characters")]
    public string name { get; set; } = String.Empty;
    [Required(ErrorMessage = "Description field is required")]
    [MinLength(15, ErrorMessage = "Description must be at least 15 characters")]
    public string description { get; set; } = String.Empty;
    [Range(1, 1000, ErrorMessage = "Price must be between 1 and 500")]
    public double price { get; set; }
    [Required(ErrorMessage = "Image url is required")]
    public string imageUrl { get; set; } = String.Empty;
    public int stock { get; set; }
    public int CategoryId { get; set; }
    public List<int>? ingredientIds { get; set; } = [];
}
