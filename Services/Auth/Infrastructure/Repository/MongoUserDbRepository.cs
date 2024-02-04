using Core.Entities;
using Core.Repository;

namespace Infrastructure.Repository;

internal sealed class MongoUserDbRepository(DbContext dbContext) : IUserRepository
{
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