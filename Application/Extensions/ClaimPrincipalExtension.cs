using System.Security.Claims;
using Domain.Common.Errors;
using Domain.Common.UserClaimsTypes;

namespace Application.Extensions;

public static class ClaimPrincipalExtension
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirstValue(UserClaims.Id);
        return userId ?? throw new ApplicationException(UserErrors.NotFound.Description);
    }
}
