namespace Auth.Core;

public readonly record struct UserId(Guid Id)
{
  public static UserId Empty = new(Guid.Empty);
  public static UserId NewUserId() => new(Guid.NewGuid());

};