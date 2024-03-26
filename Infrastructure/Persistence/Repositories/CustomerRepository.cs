using Application.Interfaces.Repositories;
using Application.Results;
using Domain.Common.Errors;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CustomerRepository(StoreDbContext dbContext) : ICustomerRepository
{
    public async Task<Result<User>> FindAsync(string userId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            return Result.Failure<User>(UserErrors.NotFound);
        }

        return Result.Success(user);
    }

    public async Task<bool> IsEmailAndUsernameUnique(string email, string username)
    {
        var result = await dbContext.Users.AnyAsync(
            u => u.Email == email || u.UserName == username
        );
        return result;
    }
}
