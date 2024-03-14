using Application.Results;
using Domain.Entity.Users;

namespace Application.Abstraction.Repository;

public interface ICustomerRepository
{
    Task<Result<User>> FindAsync(string userId);
    Task<Result<bool>> IsEmailAndUsernameUnique(string email, string username);
}
