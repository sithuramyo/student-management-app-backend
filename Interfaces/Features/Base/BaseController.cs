using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Interfaces.Features.Base;

[ApiController, Authorize]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    [NonAction]
    protected string GetCurrentUserId()
    {
        var jwtToken = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);
        return token.Subject;
    }
}