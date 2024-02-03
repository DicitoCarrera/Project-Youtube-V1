using System.Net;
using MediatR;

namespace Application;

public sealed record CreateUserCommand(string UserName, string EmailAddress, string Password) : IRequest<UserDTO> { }
