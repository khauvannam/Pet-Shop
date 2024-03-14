using System.Security.Claims;
using Application.Abstraction;
using Application.Abstraction.Repository;
using Application.Results;
using AutoMapper;
using Domain.Entity.Errors;
using Domain.Entity.UserClaimsName;
using Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repository;

public class AccountRepository(
    IMapper mapper,
    UserManager<User> userManager,
    SignInManager<User> signInManager
) : IAccountRepository
{
    public async Task<Result> Register(RegisterViewModel registerViewModel)
    {
        var user = mapper.Map<RegisterViewModel, User>(registerViewModel);
        user.SecurityStamp = Guid.NewGuid().ToString();
        var currentResult = await userManager.CreateAsync(user, registerViewModel.Password!);
        if (!currentResult.Succeeded)
        {
            return Result.Failure(UserErrors.IsUsed(user.Email!, user.UserName!));
        }

        var claims = new List<Claim>
        {
            new(UserClaims.Id, user.Id),
            new(UserClaims.Name, user.UserName!)
        };
        await userManager.AddClaimsAsync(user, claims);
        return Result.Success();
    }

    public Task<Result<string>> Login(LoginViewModel loginViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
    {
        throw new NotImplementedException();
    }
}
