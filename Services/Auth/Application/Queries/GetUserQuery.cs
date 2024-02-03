using Auth.Core;
using MediatR;

namespace Application;

public sealed record GetUserQuery(UserId Id) : IRequest<UserDTO?> { }
