using Cores.Features.Auth;
using Shares.Models.Auth;

namespace Interfaces.Features.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService service) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Login(ApiRequest<AuthRequestModel> request)
    {
        var result = await service.LoginAsync(request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
}