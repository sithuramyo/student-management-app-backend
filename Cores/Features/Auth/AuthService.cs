using Shares.Models.Auth;

namespace Cores.Features.Auth;

public class AuthService(AppDbContext context, TokenHelper tokenHelper) : IAuthService
{
    public async Task<ApiResponse<AuthResponseModel>> LoginAsync(AuthRequestModel request)
    {
        AuthResponseModel response = new();
        var data = await context.SystemUsers.FirstOrDefaultAsync(x => x.Email == request.Email && !x.IsDeleted);

        if (data is null)
        {
            return ApiResponse<AuthResponseModel>.NotFound("User does not exist");
        }

        var tokenModel = tokenHelper.GenerateToken(data.Id, data.Name, data.Role);
        response.AccessToken = tokenModel.AccessToken;
        response.ExpiresIn = tokenModel.ExpiresIn;
        return ApiResponse<AuthResponseModel>.Success(response);
    }
}