using Application.Responses;
using MediatR;

namespace Application.Commands.Register;

public sealed record RegisterCommand(string Email, string Password)
    : IRequest<AuthResponse>;