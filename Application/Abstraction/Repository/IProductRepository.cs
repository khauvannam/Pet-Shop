using Application.Results;
using Domain.Entity.Products;

namespace Application.Abstraction.Repository;

public interface IProductRepository
{
    Task<Result> CreateProduct(ProductDto productDto);
    Task<Result> EditProduct(ProductDto productDto);
    Task<Result> RemoveProduct(string productId, string userId);
    Task<Result<ICollection<Product>>> GetAllProducts();
    Task<Result<Product>> GetProductById(string productId);
}
