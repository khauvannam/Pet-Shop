using Application.Interfaces.Repositories;
using Application.Results;
using Domain.Entities.Products;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<Result> CreateProduct(ProductViewModel productDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result> EditProduct(ProductViewModel productDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result> RemoveProduct(string productId, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ICollection<Product>>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Product>> GetProductById(string productId)
    {
        throw new NotImplementedException();
    }
}
