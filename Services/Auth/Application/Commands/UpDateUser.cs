using Application.Responces;
using Core.Entities;
using MediatR;

namespace Application.Commands;

public sealed record UpDateUserCommand(UserId Id, string EmailAddress) : IRequest<UserDTO>
{
}