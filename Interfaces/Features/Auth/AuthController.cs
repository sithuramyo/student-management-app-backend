using Cores.Features.Auth;
using Shares.Models.Auth;

namespace Interfaces.Features.Auth;

public class AuthController(IAuthService service) : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ApiRequest<AuthRequestModel>),StatusCodes.Status200OK)]
    public async Task<ActionResult> Login(ApiRequest<AuthRequestModel> request)
    {
        var result = await service.LoginAsync(request.Request);
        return result.IsSuccess ? Ok(result) : StatusCode(result.StatusCode, result);
    }
}