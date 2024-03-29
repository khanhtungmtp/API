using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API._Repositories;
using API._Services.Interfaces;
using API.Dtos.UserManager;
using API.Helpers.Base;
using API.Helpers.Utilities;
using API.Models;
using API.Dtos.Base;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace API._Services.Services;

public class S_Auth(IRepositoryAccessor repositoryAccessor, IOptions<AppSettings> appSettings) : S_BaseServices(repositoryAccessor), I_Auth
{
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task<OperationResult<AuthenticateResponse>> Login(LoginDto dto)
    {
        Sys_User? user = await _repositoryAccessor.Sys_User.FirstOrDefaultAsync(x => x.UserName.TrimEnd() == dto.Username.TrimEnd() && x.IsActive);
        // Kiểm tra sự tồn tại của user
        if (user is null)
            return new OperationResult<AuthenticateResponse>(false, "Wrong username or password");

        // Nếu tồn tại user => Check password
        if (!AuthUtilities.VeryPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            return new OperationResult<AuthenticateResponse>(false, "Wrong username or password");

        // authentication successful so generate jwt token
        string? token = await GenerateJwtToken(user);
        if (token is null)
            return new OperationResult<AuthenticateResponse>(false, "User not found");
        var result = new AuthenticateResponse(user, token);
        return new OperationResult<AuthenticateResponse>(true, result);
    }

    // helper methods
    private async Task<string> GenerateJwtToken(Sys_User user)
    {
        //Generate token that is valid for 60 minutes
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.UserName) }),
                Expires = DateTime.UtcNow.AddHours(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }
}
