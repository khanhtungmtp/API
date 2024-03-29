using System.IdentityModel.Tokens.Jwt;
using System.Text;
using API._Services.Interfaces.UserManager;
using API.Dtos.Base;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Helpers;

public class JwtMiddleware(IUserManager userManager, IOptions<AppSettings> appSettings) : IMiddleware
{
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly IUserManager _userManager = userManager;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string? token = context.Request.Headers["userManagerorization"].FirstOrDefault()?.Split(" ").Last();
        if (token is not null)
        {
            await AttachUserToContext(context, _userManager, token);
        }
        await next(context);
    }

    private async Task AttachUserToContext(HttpContext context, IUserManager userManager, string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        int userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

        //Attach user to context on successful JWT validation
        context.Items["User"] = await userManager.GetById(userId);
    }
}
