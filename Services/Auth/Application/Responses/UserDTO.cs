using Core.Entities;

namespace Application.Responses;

public sealed record UserDto(
    UserId Id,
    UserName UserName,
    EmailAddress EmailAddress,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);

public static class UserExtensions
{
    public static UserDto AsDto(this User user)
    {
        return new UserDto(user.Id, user.UserName, user.EmailAddress, user.CreatedAt, user.UpdatedAt);
    }
}