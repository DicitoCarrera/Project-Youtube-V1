using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using MongoDB.Driver;

namespace Infrastructure.Persistance;

public sealed class MongoUserRepository : IUserRepository
{
    private const string UsersCollectionName = "users";
    private readonly IMongoCollection<User> Users;
    private readonly FilterDefinitionBuilder<User> FilterBuilder = Builders<User>.Filter;

    public MongoUserRepository()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("users");
        Users = database.GetCollection<User>(UsersCollectionName);
    }

    public async Task AddAsync(User user)
    {
        await Users.InsertOneAsync(user);
    }

    public async Task<User?> GetByEmailAsync(EmailAddress email)
    {
        var filter = Builders<User>.Filter.Eq("Email", email);
        var user = await Users.Find(filter).FirstOrDefaultAsync();

        return user;
    }
}