using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);

    Task<User?> GetByEmailAsync(EmailAddress email);
}