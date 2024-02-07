using Application.Responses;
using MediatR;

namespace Application.Commands;

public sealed record CreateUserCommand(
    string UserName,
    string EmailAddress,
    string Password)
    : IRequest<UserDto>
{
}