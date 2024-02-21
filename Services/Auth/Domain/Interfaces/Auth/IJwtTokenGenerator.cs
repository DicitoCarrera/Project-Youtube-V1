using Domain.Entities;

namespace Domain.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(User user);
}