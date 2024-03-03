using Application.Responses;
using Domain.Interfaces.Auth;
using Domain.Interfaces.Persistance;
using Domain.ValueObjects;
using MediatR;

namespace Application.Queries.Login;

// Correctly implement the class with inheritance and constructor
public sealed class LoginHandler(ITokenProvider tokenProvider, IUserRepository userRepository)
    : IRequestHandler<LoginQuery, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Validate the command before proceeding with the registration
        var email = EmailAddress.Create(value: query.Email);

        // Check if the user exists
        var user = await userRepository.GetByEmailAsync(email: email) ?? throw new Exception();

        // If the password is not valid, return an error
        if (!query.Password.Equals(value: user.Password.Value)) throw new Exception();

        // Generate a token for the user
        var token = await tokenProvider.GenerateToken(user: user);

        // Return the user and the token
        return new AuthResponse(User: user, Token: token);
    }
}