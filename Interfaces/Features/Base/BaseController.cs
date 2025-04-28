using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Interfaces.Features.Base;

[ApiController, Authorize]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected string GetCurrentUserId() =>
        User.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? throw new UnauthorizedAccessException();

    protected string GetCurrentUserEmail() =>
        User.FindFirstValue(JwtRegisteredClaimNames.Email) ?? throw new UnauthorizedAccessException();
}