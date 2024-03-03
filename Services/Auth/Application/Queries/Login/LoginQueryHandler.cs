using Application.Responses;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;

namespace Application.Queries.Login;

public sealed class LoginQueryHandler(ITokenProvider tokenProvider, IUserRepository userRepository)
    : IRequestHandler<LoginQuery, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Validate the command before proceeding with the registration
        var email = EmailAddress.Create(query.Email);

        // Check if the user exists
        var user = await userRepository.GetByEmailAsync(email) ?? throw new Exception("User not found.");

        // If the password is not valid, return an error
        if (!query.Password.Equals(user.Password.Value)) throw new Exception();

        // Generate a token for the user
        var token = await tokenProvider.GenerateToken(user);

        // Return the user and the token
        return new AuthResponse(user, token);
    }
}