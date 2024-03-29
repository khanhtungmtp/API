using API._Services.Interfaces.UserManager;
using API.Dtos.UserManager;
using API.Helpers.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserManager;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserManagerController(IUserManager service) : ControllerBase
{
    private readonly IUserManager _service = service;

    [HttpGet("GetData")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParam pagination, [FromQuery] UserManagerSearchParam param)
    {
        return Ok(await _service.GetAll(pagination, param));
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById([FromQuery] int id)
    {
        return Ok(await _service.GetById(id));
    }
}
