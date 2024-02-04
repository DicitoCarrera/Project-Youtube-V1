using Core.Entities;

namespace Core.Repository;

public interface IUserRepository
{
    Task<User?> GetById(UserId id);
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<User> Delete(User user);
}