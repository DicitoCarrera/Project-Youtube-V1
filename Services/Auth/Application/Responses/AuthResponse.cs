using Domain.Entities;

namespace Application.Responses;

public sealed record AuthResponse(
    User User,
    string Token
);