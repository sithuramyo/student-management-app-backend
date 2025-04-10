using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shares.Models.ApiModels;
using Shares.Models.Auth;

namespace Shares.Helpers;

public class TokenHelper(IConfiguration configuration)
{
    public TokenResponse GenerateToken(TokenModel tokenModel)
    {
        TokenResponse response = new();
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var secretKey = configuration["Jwt:Secret"];

        if (string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("JWT configuration is missing required values.");
        }

        var key = Encoding.UTF8.GetBytes(secretKey);
        var expireDays = Convert.ToInt32(configuration["Jwt:ExpireDays"]);

        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var issuedAtTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        var expirationTime = DateTimeOffset.Now.AddDays(expireDays).ToUnixTimeSeconds();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, tokenModel.Id),
            new(JwtRegisteredClaimNames.Name, tokenModel.Name),
            new(JwtRegisteredClaimNames.Email, tokenModel.Email),
            new("profile", tokenModel.Profile),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, issuedAtTime.ToString(), ClaimValueTypes.Integer64),
            new(JwtRegisteredClaimNames.Typ, tokenModel.Role),
            new(JwtRegisteredClaimNames.Nbf, issuedAtTime.ToString(), ClaimValueTypes.Integer64),
            new(JwtRegisteredClaimNames.Exp, expirationTime.ToString(), ClaimValueTypes.Integer64),
            new(JwtRegisteredClaimNames.Iss, issuer),
            new(JwtRegisteredClaimNames.Aud, audience)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(expireDays),
            signingCredentials: credentials
        );
        return new TokenResponse { AccessToken = new JwtSecurityTokenHandler().WriteToken(token), ExpiresIn = expirationTime };
    }
}