using Application.Results;
using Domain.Entities.Users;

namespace Application.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Result<User>> FindAsync(string userId);
    Task<bool> IsEmailAndUsernameUnique(string email, string username);
}
