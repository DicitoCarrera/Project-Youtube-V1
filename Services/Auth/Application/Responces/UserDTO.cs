using Core.Entities;

namespace Application.Responces;

public sealed record UserDTO(UserId Id, string UserName, string EmailAddress)
{
    public static UserDTO FromUser(User user)
    {
        return new UserDTO(user.Id, user.UserName, user.EmailAddress);
    }
}