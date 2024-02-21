using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed record User : Entity
{
    private User(
        UserId id,
        UserName userName,
        EmailAddress emailAddress,
        Password password,
        DateTimeOffset createdAt,
        DateTimeOffset upDatedAt) : base(id)
    {
        Id = id;
        Name = userName;
        Password = password;
        Email = emailAddress;
        UpDatedAt = upDatedAt;
        CreatedAt = createdAt;
    }

    public new UserId Id { get; }
    public UserName Name { get; }
    public EmailAddress Email { get; }
    public Password Password { get; }
    public DateTimeOffset CreatedAt { get; }
    public DateTimeOffset UpDatedAt { get; }

    public static Result<User> Create(string username, string email, string password)
    {
        var emailAddress = EmailAddress.Create(email);

        if (emailAddress.IsFailure) return emailAddress.Error;

        var userName = UserName.Create(username);

        if (userName.IsFailure) return userName.Error;

        var passwordValue = Password.Create(password);

        if (passwordValue.IsFailure) return passwordValue.Error;

        return new User(
            UserId.NewUserId(),
            userName.Value,
            emailAddress.Value,
            passwordValue.Value,
            DateTimeOffset.Now,
            DateTimeOffset.Now);
    }
}