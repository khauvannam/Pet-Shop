using System.Security.Claims;
using Domain.Entity.Errors;
using Domain.Entity.UserClaimsName;

namespace Application.Abstraction.Extensions;

public static class ClaimPrincipalExtension
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirstValue(UserClaims.Id);
        return userId ?? throw new ApplicationException(UserErrors.NotFound.Description);
    }
}
