using Application.Responses;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Register;

public sealed class RegisterCommandHandler(
    ITokenProvider tokenProvider,
    IUserRepository userRepository)
    : IRequestHandler<RegisterCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        // Validate the command before proceeding with the registration
        var email = EmailAddress.Create(command.Email);
        var password = Password.Create(command.Password);

        // Check if the user already exists in the database (email address) 
        if (userRepository.GetByEmailAsync(email).Result is not null)
            throw new Exception("Email address already in use.");

        // Create a new user
        var newUser = User.Create(email, password);
        await userRepository.AddAsync(newUser);
        var token = await tokenProvider.GenerateToken(newUser);
        return new AuthResponse(newUser, token);
    }
}