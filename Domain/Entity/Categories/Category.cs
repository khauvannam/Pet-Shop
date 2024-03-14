using Domain.Entity.Products;

namespace Domain.Entity.Categories;

public class Category
{
    public string CategoryId = Guid.NewGuid().ToString();
    public List<Product>? Products { get; init; }
}
