namespace Domain.Entity.Products;

public class Product
{
    public string ProductId = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string Size { get; set; }
    public List<ProductPictures>? ProductPicturesList { get; set; }
}
