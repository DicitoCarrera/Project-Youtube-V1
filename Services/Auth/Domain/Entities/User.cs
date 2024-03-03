using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class User
{
    private User(
        UserId id,
        EmailAddress emailAddress,
        Password password,
        DateTimeOffset createdAt
    )
    {
        Id = id;
        Password = password;
        Email = emailAddress;
        CreatedAt = createdAt;
    }

    public UserId Id { get; }
    public EmailAddress Email { get; }
    public Password Password { get; }
    public DateTimeOffset CreatedAt { get; }

    public static User Create(EmailAddress emailAddress, Password password)
    {
        return new User(
            UserId.NewUserId(),
            emailAddress,
            password,
            DateTimeOffset.Now);
    }
}