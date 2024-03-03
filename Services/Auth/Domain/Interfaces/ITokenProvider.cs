using Domain.Entities;

namespace Domain.Interfaces;

public interface ITokenProvider
{
    Task<string> GenerateToken(User user);
}