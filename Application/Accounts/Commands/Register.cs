using Application.Abstraction.Repository;
using Application.Results;
using AutoMapper;
using Domain.Entity.Errors;
using Domain.Entity.Users;
using MediatR;

namespace Application.Accounts.Commands;

public sealed class Register
{
    public class Command : IRequest<Result>
    {
        public string Email { get; init; } = null!;
        public string UserName { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string ConfirmPassword { get; init; } = null!;
    }

    public class Handler(
        IAccountRepository accountRepository,
        ICustomerRepository customerRepository,
        IMapper mapper
    ) : IRequestHandler<Command, Result>
    {
        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<Command, RegisterViewModel>(request);
            var result = await customerRepository.IsEmailAndUsernameUnique(
                model.UserName!,
                model.Email!
            );
            if (!result.Value)
            {
                return Result.Failure<bool>(UserErrors.IsUsed(model.Email!, model.UserName!));
            }

            return await accountRepository.Register(model);
        }
    }
}
