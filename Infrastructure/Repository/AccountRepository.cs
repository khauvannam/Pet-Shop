using Application.Abstraction;
using Application.Results;
using Domain.Entity.Users;

namespace Infrastructure.Repository;

public class AccountRepository : IAccountRepository
{
    public Task<Result<string>> Register(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> Login(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        throw new NotImplementedException();
    }
}