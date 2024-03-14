using Domain.Entity.Products;
using FluentValidation;

namespace Application.Validator;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(20)
            .WithMessage("Product name has to at least 5 words and maximum at 20 words");
    }
}
