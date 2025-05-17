using FactoryProject.Models;
using FactoryProject.Models.CategoryDtos;
using FactoryProject.Models.IngredientDtos;
using FactoryProject.Models.OrderDtos;
using FactoryProject.Models.ProductDtos;

namespace FactoryProject.Infrastructure.Utilities.Services;

public class GenericStateService<T>
{
    public string SuccessMessage { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    private List<T> _models = [];
    public event Action? OnModelsChanged;
    public List<T> Models
    {
        get => _models;
        set
        {
            _models = value;
            OnModelsChanged?.Invoke();
        }
    }
    public void SetItems(List<T> models)
    {
        Models = models;
    }
    public void AddItem(T model)
    {
        //book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1; // Assign a new ID
        _models.Add(model);
        var msg = $"An new item is successfully added.";
        SetSuccessMessage(msg);
        OnModelsChanged?.Invoke();
    }
    public void RemoveItem(T model)
    {
        if (model == null) return;
        _models.Remove(model);
        var msg = $"An item is successfully deleted.";
        SetSuccessMessage(msg);
        OnModelsChanged?.Invoke();
    }
    public void UpdateItem(T model, int index)
    {
        if (index != -1)
        {
            _models[index] = model;
            SetSuccessMessage($"An item is successfully updated.");
            OnModelsChanged?.Invoke();
        }
    }

    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
public class ProductStateService
{
    private List<ResultProductDto> _products = [];
    public event Action? OnProductsChanged;

    public List<ResultProductDto> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnProductsChanged?.Invoke();
        }
    }
    public void SetProducts(List<ResultProductDto> products)
    {
        Products = products;
    }
    public void AddProduct(ResultProductDto product)
    {
        product.Id = _products.Count > 0 ? _products.Max(b => b.Id) + 1 : 1; // Assign a new ID
        _products.Add(product);
        var msg = $"Product {product.Name} is successfully added.";
        SetSuccessMessage(msg);
        OnProductsChanged?.Invoke();
    }
    public void RemoveProduct(int id)
    {
        var item = _products.FirstOrDefault(b => b.Id == id);
        if (item == null) return;
        _products.Remove(item);
        var msg = $"Product with ID {id} is successfully deleted.";
        SetSuccessMessage(msg);
        OnProductsChanged?.Invoke();
    }
    public void UpdateProduct(ResultProductDto product)
    {
        var index = _products.FindIndex(b => b.Id == product.Id);
        if (index != -1)
        {
            _products[index] = product;
            OnProductsChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
public class CategoryStateService
{
    private List<ResultCategoryDto> _categories = [];
    public event Action? OnCategoriesChanged;

    public List<ResultCategoryDto> Categories
    {
        get => _categories;
        set
        {
            _categories = value;
            OnCategoriesChanged?.Invoke();
        }
    }
    public void SetCategories(List<ResultCategoryDto> categories)
    {
        Categories = categories;
    }
    public void AddCategory(ResultCategoryDto category)
    {
        category.id = _categories.Count > 0 ? _categories.Max(b => b.id) + 1 : 1; // Assign a new ID
        _categories.Add(category);
        var msg = $"Category {category.name} is successfully added.";
        SetSuccessMessage(msg);
        OnCategoriesChanged?.Invoke();
    }
    public void RemoveCategory(int id)
    {
        var item = _categories.FirstOrDefault(b => b.id == id);
        if (item == null) return;
        _categories.Remove(item);
        var msg = $"Category with ID {id} is successfully deleted.";
        SetSuccessMessage(msg);
        OnCategoriesChanged?.Invoke();
    }
    public void UpdateCategory(ResultCategoryDto category)
    {
        var index = _categories.FindIndex(b => b.id == category.id);
        if (index != -1)
        {
            _categories[index] = category;
            OnCategoriesChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
public class PersonalStateService
{
    private List<ResultPersonalDto> _personals = [];
    public event Action? OnPersonalsChanged;

    public List<ResultPersonalDto> Personals
    {
        get => _personals;
        set
        {
            _personals = value;
            OnPersonalsChanged?.Invoke();
        }
    }
    public void SetPersonals(List<ResultPersonalDto> personals)
    {
        Personals = personals;
    }
    public void AddPersonal(ResultPersonalDto personal)
    {
        personal.id = _personals.Count > 0 ? _personals.Max(b => b.id) + 1 : 1; // Assign a new ID
        _personals.Add(personal);
        var msg = $"Personal {personal.name} is successfully added.";
        SetSuccessMessage(msg);
        OnPersonalsChanged?.Invoke();
    }
    public void RemovePersonal(int id)
    {
        var item = _personals.FirstOrDefault(b => b.id == id);
        if (item == null) return;
        _personals.Remove(item);
        var msg = $"Personal with ID {id} is successfully deleted.";
        SetSuccessMessage(msg);
        OnPersonalsChanged?.Invoke();
    }
    public void UpdatePersonal(ResultPersonalDto personal)
    {
        var index = _personals.FindIndex(b => b.id == personal.id);
        if (index != -1)
        {
            _personals[index] = personal;
            OnPersonalsChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
public class DepartmentStateService
{

    private List<ResultDepartmentDto> _departments = [];
    public event Action? OnDepartmentsChanged;

    public List<ResultDepartmentDto> Departments
    {
        get => _departments;
        set
        {
            _departments = value;
            OnDepartmentsChanged?.Invoke();
        }
    }
    public void SetDepartments(List<ResultDepartmentDto> departments)
    {
        Departments = departments;
    }
    public void AddDepartment(ResultDepartmentDto department)
    {
        department.id = _departments.Count > 0 ? _departments.Max(b => b.id) + 1 : 1; // Assign a new ID
        _departments.Add(department);
        var msg = $"Personal {department.name} is successfully added.";
        SetSuccessMessage(msg);
        OnDepartmentsChanged?.Invoke();
    }
    public void RemoveDepartment(int id)
    {
        var item = _departments.FirstOrDefault(b => b.id == id);
        if (item == null) return;
        _departments.Remove(item);
        var msg = $"Department with ID {id} is successfully deleted.";
        OnDepartmentsChanged?.Invoke();
    }
    public void UpdateDepartment(ResultDepartmentDto personal)
    {
        var index = _departments.FindIndex(b => b.id == personal.id);
        if (index != -1)
        {
            _departments[index] = personal;
            OnDepartmentsChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
public class IngredientStateService
{

    private List<ResultIngredientDto> _ingredients = [];
    public event Action? OnIngredientsChanged;

    public List<ResultIngredientDto> Ingredients
    {
        get => _ingredients;
        set
        {
            _ingredients = value;
            OnIngredientsChanged?.Invoke();
        }
    }
    public void SetIngredients(List<ResultIngredientDto> ingredients)
    {
        Ingredients = ingredients;
    }
    public void AddIngredient(ResultIngredientDto ingredient)
    {
        ingredient.id = _ingredients.Count > 0 ? _ingredients.Max(b => b.id) + 1 : 1; // Assign a new ID
        _ingredients.Add(ingredient);
        var msg = $"Ingredient {ingredient.name} is successfully added.";
        SetSuccessMessage(msg);
        OnIngredientsChanged?.Invoke();
    }
    public void RemoveIngredient(int id)
    {
        var item = _ingredients.FirstOrDefault(b => b.id == id);
        if (item == null) return;
        _ingredients.Remove(item);
        var msg = $"Ingredient with ID {id} is successfully deleted.";
        OnIngredientsChanged?.Invoke();
    }
    public void UpdateIngredient(ResultIngredientDto ingredient)
    {
        var index = _ingredients.FindIndex(b => b.id == ingredient.id);
        if (index != -1)
        {
            _ingredients[index] = ingredient;
            OnIngredientsChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
public class OrderStateService
{
    private List<ResultOrderDto> _orders = [];
    public event Action? OnOrderChanged;

    public List<ResultOrderDto> Orders
    {
        get => _orders;
        set
        {
            _orders = value;
            OnOrderChanged?.Invoke();
        }
    }
    public void SetOrders(List<ResultOrderDto> orders)
    {
        Orders = orders;
    }
    public void AddOrder(ResultOrderDto order)
    {
        order.id = _orders.Count > 0 ? _orders.Max(b => b.id) + 1 : 1; // Assign a new ID
        _orders.Add(order);
        var msg = $"An order item  is successfully added.";
        SetSuccessMessage(msg);
        OnOrderChanged?.Invoke();
    }
    public void RemoveOrder(int id)
    {
        var item = _orders.FirstOrDefault(b => b.id == id);
        if (item == null) return;
        _orders.Remove(item);
        var msg = $"Order with ID {id} is successfully deleted.";
        OnOrderChanged?.Invoke();
    }
    public void UpdateOrder(ResultOrderDto order)
    {
        var index = _orders.FindIndex(b => b.id == order.id);
        if (index != -1)
        {
            _orders[index] = order;
            OnOrderChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
        {
            await Task.Delay(5000);//5 seconds delay
            Reset();
        });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}



