using Application.Abstraction;
using Application.Abstraction.Repository;
using Application.Results;
using Domain.Entity.Products;

namespace Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    public Task<Result> CreateProduct(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result> EditProduct(ProductDto productDto)
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
