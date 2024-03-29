using API._Services.Interfaces.UserManager;
using API.Dtos.UserManager;
using API.Helpers.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserManager;

[ApiController]
[Route("api/[controller]")]
public class UserManagerController : ControllerBase
{
    private readonly IUserManager _service;

    public UserManagerController(IUserManager service)
    {
        _service = service;
    }
    [HttpGet("GetData")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParam pagination, [FromQuery] UserManagerSearchParam param)
    {
        var result = await _service.GetAll(pagination, param);
        return Ok(result);
    }
}
