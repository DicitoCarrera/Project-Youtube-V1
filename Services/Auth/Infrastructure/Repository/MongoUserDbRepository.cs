using Auth.Core;

namespace Infrastructure;

internal sealed class MongoUserDbRepository : IUserRepository
{
  private readonly DbContext _dbContext;
  public MongoUserDbRepository(DbContext _dbContext)
  {
    _dbContext = _dbContext;
  }
  public Task<User> Create(User user)
  {
    throw new NotImplementedException();
  }

  public Task<User> Delete(User user)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetById(UserId id)
  {
    throw new NotImplementedException();
  }

  public Task<User> Update(User user)
  {
    throw new NotImplementedException();
  }
}

internal class DbContext
{
}