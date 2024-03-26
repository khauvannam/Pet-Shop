namespace Domain.Entities.Products;

public class Product
{
    public string ProductId = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Description { get; set; }
}
