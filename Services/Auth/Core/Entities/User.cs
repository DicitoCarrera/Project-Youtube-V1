
namespace Core.Entities;

public sealed record User(
    UserId Id,
    UserName UserName,
    EmailAddress EmailAddress,
    Password Password,
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
            UserName.Create(userName),
            EmailAddress.Create(emailAddress),
            Password.Create(password),
            DateTimeOffset.Now,
            updatedAt
        );
    }
}