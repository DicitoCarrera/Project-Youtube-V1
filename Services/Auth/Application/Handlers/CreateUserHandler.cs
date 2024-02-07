using Application.Commands;
using Application.Responses;
using Core.Entities;
using Core.Repository;
using MediatR;

namespace Application.Handlers;

internal sealed class CreateUserHandler(IUserRepository repository)
    : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = request.Password;

        var user = await repository.Create(
            User.NewUser(
                request.UserName,
                request.EmailAddress,
                hashedPassword,
                DateTimeOffset.Now
            )
        );

        return user.AsDto();
    }
}