using Auth.Core;

namespace Application;

public sealed record UserDTO(UserId Id, string UserName, string EmailAddress)
{
  public static UserDTO FromUser(User user) => new(user.Id, user.UserName, user.EmailAddress);
}
