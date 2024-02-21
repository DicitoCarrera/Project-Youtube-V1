using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

public sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    public async Task<string> GenerateToken(User user)
    {
        // Your secret key should be stored securely and should be retrieved from a secure place.
        // Hardcoding it in your source code is not recommended for production environments.
        // var secretKey = "super-secret-key";
        var secretKey = "your-very-long-and-secure-secret-key-here-with-at-least-32-bytes-length";

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.GivenName, user.Name.Value),
            new(JwtRegisteredClaimNames.Email, user.Email.Value),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var tokenOptions = new JwtSecurityToken(
            "YourIssuer", // Replace with your issuer
            "YourAudience", // Replace with your audience
            claims,
            expires: DateTime.UtcNow.AddDays(1), // Using UtcNow is generally a good practice
            signingCredentials: signingCredentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }
}