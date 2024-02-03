namespace Auth.Core;

public interface IUserRepository
{
  Task<User?> GetById(UserId id);
  Task<User> Create(User user);
  Task<User> Update(User user);
  Task Delete(User user);
}
