using Application.Responses;
using MediatR;

namespace Application.Queries.Login;

public sealed record LoginQuery(string Email, string Password)
    : IRequest<AuthResponse>;