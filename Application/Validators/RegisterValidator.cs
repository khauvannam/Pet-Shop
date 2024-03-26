using Domain.Entities.Users;
using FluentValidation;

namespace Application.Validators;

public class RegisterValidator : AbstractValidator<RegisterViewModel>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password must at least 8 characters");
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password)
            .WithMessage("Password not match");
    }
}
