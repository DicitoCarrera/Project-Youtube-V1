using Application.Responses;
using Domain.Abstractions;
using MediatR;

namespace Application.Queries.Login;

public sealed record LoginUserQuery(string Email, string Password) : IRequest<Result<AuthResponse>>;