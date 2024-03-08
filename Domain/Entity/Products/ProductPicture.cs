namespace Domain.Entity.Products;

public class ProductPicture
{
    public string PictrueId { get; set; }
    public string Link { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }
}
