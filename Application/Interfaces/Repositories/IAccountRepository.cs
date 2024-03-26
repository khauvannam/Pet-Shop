using Application.Results;
using Domain.Entities.Users;

namespace Application.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<Result> Register(RegisterViewModel registerViewModel);
    /*Task<Result<string>> Login(LoginViewModel loginViewModel);
    Task<Result<string>> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel);
    Task<Result<string>> ResetPassword(ResetPasswordViewModel resetPasswordViewModel);*/
}