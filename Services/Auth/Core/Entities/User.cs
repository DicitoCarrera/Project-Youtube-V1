
namespace Auth.Core;

public sealed record User(
  UserId Id,
  String UserName,
  String EmailAddress,
  String Password,
  DateTimeOffset CreatedAt,
  DateTimeOffset UpdatedAt)
{
  public static User NewUser(
    string userName,
    string emailAddress,
    string password,
    DateTimeOffset updatedAt)
    => new(
      UserId.NewUserId(),
      userName,
      emailAddress,
      password,
      DateTimeOffset.Now,
      updatedAt
      );
};

