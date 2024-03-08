using Application.Abstraction.Repository;
using Application.Results;
using AutoMapper;
using Domain.Entity.Users;
using MediatR;

namespace Application.AccountHandler.Commands;

public sealed class Register
{
    public class Command : IRequest<Result<string>>
    {
        public string Email { get; init; } = null!;
        public string UserName { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string ConfirmPassword { get; init; } = null!;
    }

    public class Handler(IAccountRepository accountRepository, IMapper mapper)
        : IRequestHandler<Command, Result<string>>
    {
        public async Task<Result<string>> Handle(
            Command request,
            CancellationToken cancellationToken
        )
        {
            var model = mapper.Map<Command, RegisterViewModel>(request);
            return await accountRepository.Register(model);
        }
    }
}
