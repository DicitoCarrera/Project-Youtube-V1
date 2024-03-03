using Domain.Entities;

namespace Domain.Interfaces.Auth;

public interface ITokenProvider
{
    Task<string> GenerateToken(User user);
}