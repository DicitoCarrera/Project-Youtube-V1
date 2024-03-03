using Domain.Entities;
using Domain.Interfaces.Persistance;
using Domain.ValueObjects;

namespace Infrastructure.Persistance;

public sealed class MongoUserRepository : IUserRepository
{
    private static readonly List<User> Users = [];

    public async Task AddAsync(User user)
    {
        Users.Add(item: user);
    }

    public async Task<User?> GetByEmailAsync(EmailAddress email)
    {
        return Users.SingleOrDefault(predicate: u => u.Email.Equals(other: email));
    }
}