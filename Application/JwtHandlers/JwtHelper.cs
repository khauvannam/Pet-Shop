using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Application.JwtHandlers;

public static class JwtHelper
{
    private static TokenValidationParameters GetTokenValidationParameters(string jwtSecret)
    {
        return new TokenValidationParameters
        {
            ValidAudience = "http://localhost:5085 ",
            ValidateAudience = false,
            ValidIssuer = "http://localhost:5085",
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };
    }

    public static void BearerOptionsConfig(this JwtBearerOptions option, string jwtSecret)
    {
        option.SaveToken = true;
        option.TokenValidationParameters = GetTokenValidationParameters(jwtSecret);
    }
}
