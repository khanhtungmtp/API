using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
namespace API.Configurations;
public static class AuthenticationConfig
{
    public static void AddAuthenticationConfigufation(this IServiceCollection services, IConfiguration configuration)
    {
        string? secret = configuration.GetSection("AppSettings:Secret")?.Value ?? throw new Exception("secret is null");

        // add autentication
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(secret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}