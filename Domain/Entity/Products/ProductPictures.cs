namespace Domain.Entity.Products;

public class ProductPictures
{
    public string PictrueId { get; set; }
    public string Link { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }
}
