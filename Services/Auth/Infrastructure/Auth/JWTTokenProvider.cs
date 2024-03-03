using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

public sealed class JwtTokenProvider : ITokenProvider
{
    public async Task<string> GenerateToken(User user)
    {
        // Your secret key should be stored securely and should be retrieved from a secure place.
        // Hardcoding it in your source code is not recommended for production environments.
        // var secretKey = "super-secret-key";
        var secretKey
            = "your-very-long-and-secure-secret-key-here-with-at-least-32-bytes-length";

        var signingKey
            = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(s: secretKey));

        var signingCredentials
            = new SigningCredentials(key: signingKey, algorithm: SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, value: user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, value: user.Email.Value),
            new(JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString())
        };

        var tokenOptions = new JwtSecurityToken(
            issuer: "YourIssuer", // Replace with your issuer
            audience: "YourAudience", // Replace with your audience
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1), // Using UtcNow is generally a good practice
            signingCredentials: signingCredentials
        );

        var tokenString
            = new JwtSecurityTokenHandler().WriteToken(token: tokenOptions);

        return tokenString;
    }
}