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

        TokenModel tokenModel = new()
        {
            Id = data.Id,
            Name = data.Name,
            Email = data.Email,
            Role = data.Role,
            Profile = data.Profile ?? string.Empty,
        };
        var tokenResModel = tokenHelper.GenerateToken(tokenModel);
        response.AccessToken = tokenResModel.AccessToken;
        response.ExpiresIn = tokenResModel.ExpiresIn;
        return ApiResponse<AuthResponseModel>.Success(response);
    }
}