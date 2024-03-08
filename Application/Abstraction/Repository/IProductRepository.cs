using Application.Results;
using Domain.Entity.Products;

namespace Application.Abstraction.Repository;

public interface IProductRepository
{
    Task<Result<string>> CreateProduct(ProductDto productDto);
    Task<Result<string>> EditProduct(ProductDto productDto);
    Task<Result<string>> RemoveProduct(string productId, string userId);
    Task<Result<ICollection<Product>>> GetAllProducts();
    Task<Result<Product>> GetProductById(string productId);
}
