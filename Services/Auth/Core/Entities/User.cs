namespace Core.Entities;

public sealed record User(
    UserId Id,
    string UserName,
    string EmailAddress,
    string Password,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt)
{
    public static User NewUser(
        string userName,
        string emailAddress,
        string password,
        DateTimeOffset updatedAt)
    {
        return new User(
            UserId.NewUserId(),
            userName,
            emailAddress,
            password,
            DateTimeOffset.Now,
            updatedAt
        );
    }
}