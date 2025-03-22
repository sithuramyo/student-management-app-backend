namespace Shares.Models.ApiModels;

public class TokenResponse
{
    public string AccessToken { get; set; } = null!;
    public long ExpiresIn { get; set; }
}