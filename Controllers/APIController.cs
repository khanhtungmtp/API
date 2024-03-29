using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class APIController : ControllerBase
    {
        protected string UserName => (HttpContext.User.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
    }
}