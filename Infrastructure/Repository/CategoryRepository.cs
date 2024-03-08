using Application.Abstraction;
using Application.Abstraction.Repository;
using Application.Results;
using Domain.Entity.Categories;

namespace Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{
    public Task<Result<string>> CreateCategory(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> DeleteCategory(string categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ICollection<Category>>> ListAllCategories()
    {
        throw new NotImplementedException();
    }
}
