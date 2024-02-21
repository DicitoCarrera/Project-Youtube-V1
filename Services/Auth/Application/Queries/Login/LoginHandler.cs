using Application.Errors;
using Application.Responses;
using Domain.Abstractions;
using Domain.Interfaces.Auth;
using Domain.Interfaces.Persistance;
using Domain.ValueObjects;
using MediatR;

namespace Application.Queries.Login;

// Correctly implement the class with inheritance and constructor
public sealed class LoginHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IRequestHandler<LoginUserQuery, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(LoginUserQuery query, CancellationToken cancellationToken)
    {
        // Validate the command before proceeding with the registration
        var email = EmailAddress.Create(query.Email);

        // If the email is not valid, return an error
        if (email.IsFailure) return AuthErrors.InvalidEmail;

        // Check if the user exists
        var user = await userRepository.GetByEmailAsync(email.Value);

        // If the user does not exist, return an error
        if (user is null) return AuthErrors.UserNotFound;

        // If the password is not valid, return an error
        if (!query.Password.Equals(user.Password.Value)) return AuthErrors.InvalidCredentials;

        // Generate a token for the user
        var token = await jwtTokenGenerator.GenerateToken(user);

        // Return the user and the token
        return new AuthResponse(user, token);
    }
}