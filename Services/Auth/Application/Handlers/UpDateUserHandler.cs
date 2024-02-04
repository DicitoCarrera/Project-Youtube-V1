using Application.Commands;
using Application.Responces;
using Core.Repository;
using MediatR;

namespace Application.Handlers;

public sealed class UpDateUserHandler(IUserRepository repository)
    : IRequestHandler<UpDateUserCommand, UserDTO>
{
    public async Task<UserDTO> Handle(UpDateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(request.Id);
        if (user != null)
        {
            var updatedUser = await repository.Update(user with
            {
                EmailAddress = request.EmailAddress, UpdatedAt = DateTimeOffset.Now
            });
            return UserDTO.FromUser(updatedUser);
        }

        return null;
    }
}