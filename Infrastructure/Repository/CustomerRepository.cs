using Application.Abstraction.Repository;
using Application.Results;
using Domain.Entity.Errors;
using Domain.Entity.Users;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

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

    public async Task<Result<bool>> IsEmailAndUsernameUnique(string email, string username)
    {
        var isUnique = await dbContext.Users.AnyAsync(
            u => u.Email == email || u.UserName == username
        );
        return Result.Success(!isUnique);
    }
}
