using Application.Results;
using Domain.Entity.Users;

namespace Application.Abstraction.Repository;

public interface IAccountRepository
{
    Task<Result<string>> Register(RegisterViewModel registerViewModel);
    Task<Result<string>> Login(LoginViewModel loginViewModel);
    Task<Result<string>> ForgotPassword(ForgotPasswordDto forgotPasswordDto);
    Task<Result<string>> ResetPassword(ResetPasswordDto resetPasswordDto);
}
