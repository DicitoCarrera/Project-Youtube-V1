using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class User : Entity
{
    private User(
        UserId id,
        EmailAddress emailAddress,
        Password password,
        DateTimeOffset createdAt
    )
        : base(id)
    {
        Password = password;
        Email = emailAddress;
        CreatedAt = createdAt;
    }

    public EmailAddress Email { get; }
    public Password Password { get; }
    public DateTimeOffset CreatedAt { get; }

    public static User Create(EmailAddress emailAddress, Password password)
    {
        return new User(
            id: UserId.NewUserId(),
            emailAddress: emailAddress,
            password: password,
            createdAt: DateTimeOffset.Now);
    }
}