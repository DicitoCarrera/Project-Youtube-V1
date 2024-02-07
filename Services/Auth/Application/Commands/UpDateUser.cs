using Application.Responses;
using Core.Entities;
using MediatR;

namespace Application.Commands;

public sealed record UpDateUserCommand(UserId Id, EmailAddress EmailAddress) : IRequest<UserDto>
{
}