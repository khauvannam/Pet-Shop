using Application.Results;
using Domain.Entity.Users;

namespace Application.Abstraction;

public interface IAccountRepository
{
    Task<Result<string>> Register(RegisterDto registerDto);
    Task<Result<string>> Login(LoginDto loginDto);
    Task<Result<string>> ForgotPassword(ForgotPasswordDto forgotPasswordDto);
    Task<Result<string>> ResetPassword(ResetPasswordDto resetPasswordDto);
}
