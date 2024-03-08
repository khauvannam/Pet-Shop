using Application.Results;
using Domain.Entity.Categories;

namespace Application.Abstraction.Repository;

public interface ICategoryRepository
{
    Task<Result<string>> CreateCategory(CategoryDto categoryDto);
    Task<Result<string>> DeleteCategory(string categoryId);
    Task<Result<ICollection<Category>>> ListAllCategories();
}
