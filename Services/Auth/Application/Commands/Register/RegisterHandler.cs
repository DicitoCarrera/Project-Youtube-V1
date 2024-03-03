using Application.Responses;
using Domain.Entities;
using Domain.Interfaces.Auth;
using Domain.Interfaces.Persistance;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Register;

public sealed class RegisterHandler(ITokenProvider tokenProvider, IUserRepository userRepository)
    : IRequestHandler<RegisterCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // Validate the command before proceeding with the registration
        var email = EmailAddress.Create(value: command.Email);
        var password = Password.Create(value: command.Password);

        // Check if the user already exists in the database (email address) 

        if (userRepository.GetByEmailAsync(email: email).Result is not null)
            throw new Exception();

        // Create a new user
        var newUser = User.Create(emailAddress: email, password: password);

        await userRepository.AddAsync(user: newUser);

        var token = await tokenProvider.GenerateToken(user: newUser);

        return new AuthResponse(User: newUser, Token: token);
    }
}