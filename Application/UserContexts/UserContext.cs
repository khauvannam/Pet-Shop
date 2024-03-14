using Application.Abstraction.Extensions;
using Application.Abstraction.Services;
using Domain.Entity.Errors;
using Microsoft.AspNetCore.Http;

namespace Application.UserContexts;

public class UserContext(IHttpContextAccessor httpContext) : IUserContext
{
    public string UserId =>
        httpContext.HttpContext?.User.GetUserId()
        ?? throw new ApplicationException(UserErrors.NotFound.Description);
}
