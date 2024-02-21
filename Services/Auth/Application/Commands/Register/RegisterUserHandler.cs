using Application.Errors;
using Application.Responses;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Interfaces.Auth;
using Domain.Interfaces.Persistance;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Register;

public sealed class RegisterUserHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IRequestHandler<RegisterUserCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        // Validate the command before proceeding with the registration
        var email = EmailAddress.Create(command.Email);

        if (email.IsFailure) return AuthErrors.InvalidEmail;

        // Check if the user already exists in the database (email address) 

        if (userRepository.GetByEmailAsync(email.Value).Result is not null)
            return AuthErrors.UserAlreadyExists;

        // Create a new user
        var newUser = User.Create(
            command.UserName,
            command.Email,
            command.Password);

        if (newUser.IsFailure) return newUser.Error;

        await userRepository.AddAsync(newUser.Value);

        var token = await jwtTokenGenerator.GenerateToken(newUser.Value);

        return new AuthResponse(newUser.Value, token);
    }
}