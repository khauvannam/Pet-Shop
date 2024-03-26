using Application.Interfaces.Repositories;
using Application.Results;
using AutoMapper;
using Domain.Common.Errors;
using Domain.Entities.Users;
using MediatR;

namespace Application.Commands.Accounts;

public sealed class Register
{
    public record Command(string Email, string Username, string Password, string ConfirmPassword)
        : IRequest<Result>;

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
            if (!result)
            {
                return Result.Failure(UserErrors.IsUsed(model.Email!, model.UserName!));
            }

            return await accountRepository.Register(model);
        }
    }
}
