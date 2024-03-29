using API.Models;

namespace API.Dtos.UserManager;

public class AuthenticateResponse(Sys_User user, string token)
{
    public int Id { get; set; } = user.Id;
    public string FullName { get; set; } = user.FullName;
    public string UserName { get; set; } = user.UserName;
    public string Token { get; set; } = token;
}
