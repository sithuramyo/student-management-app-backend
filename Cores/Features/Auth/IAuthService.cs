using Shares.Models.ApiModels;
using Shares.Models.Auth;

namespace Cores.Features.Auth;

public interface IAuthService
{
    Task<ApiResponse<AuthResponseModel>> LoginAsync(AuthRequestModel request);
}