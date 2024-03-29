using API._Services.Interfaces;
using API.Dtos.UserManager;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(I_Auth auth) : ControllerBase
{
    private readonly I_Auth _auth = auth;

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto param)
    {
        var result = await _auth.Login(param);
        if (!result.IsSuccess) return BadRequest(result.Messages);
        return Ok(result);
    }

}
