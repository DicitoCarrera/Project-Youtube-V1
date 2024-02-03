using Auth.Core;
using MediatR;

namespace Application;

public sealed record UpDateUserCommand(UserId Id, string EmailAddress) : IRequest<UserDTO>
{
}
