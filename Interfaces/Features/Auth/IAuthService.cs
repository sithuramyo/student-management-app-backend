using Shares.Models.Auth;

namespace Interfaces.Features.Auth;

public interface IAuthService
{
    Task<ApiResponse<AuthResponseModel>> LoginAsync(AuthRequestModel request);
}