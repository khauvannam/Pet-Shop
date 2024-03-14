using Application.Results;
using Domain.Entity.Categories;

namespace Application.Abstraction.Repository;

public interface ICategoryRepository
{
    Task<Result> CreateCategory(CategoryDto categoryDto);
    Task<Result> DeleteCategory(string categoryId);
    Task<Result> EditCategory(string categoryId);
    Task<Result<ICollection<Category>>> ListAllCategories();
}
