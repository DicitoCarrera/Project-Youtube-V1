using Domain.Entities;
using Domain.Interfaces.Persistance;
using Domain.ValueObjects;

namespace Infrastructure.Persistance;

public sealed class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public async Task AddAsync(User user)
    {
        _users.Add(user);
    }

    public async Task<User?> GetByEmailAsync(EmailAddress email)
    {
        return _users.SingleOrDefault(u => u.Email.Equals(email));
    }
}