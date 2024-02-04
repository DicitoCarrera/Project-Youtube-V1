using Application.Responces;
using Core.Entities;
using MediatR;

namespace Application.Queries;

public sealed record GetUserQuery(UserId Id) : IRequest<UserDTO?>
{
}