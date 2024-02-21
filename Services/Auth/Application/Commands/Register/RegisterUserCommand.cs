using Application.Responses;
using Domain.Abstractions;
using MediatR;

namespace Application.Commands.Register;

public sealed record RegisterUserCommand(string UserName, string Email, string Password)
    : IRequest<Result<AuthResponse>>;