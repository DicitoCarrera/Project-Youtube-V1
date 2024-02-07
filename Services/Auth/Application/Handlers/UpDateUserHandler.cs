using Application.Commands;
using Application.Responses;
using Core.Repository;
using MediatR;

namespace Application.Handlers;

public sealed class UpDateUserHandler(IUserRepository repository)
    : IRequestHandler<UpDateUserCommand, UserDto>
{
    public async Task<UserDto?> Handle(UpDateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(request.Id);
        if (user == null) return null;
        var updatedUser = user with
        {
            EmailAddress = request.EmailAddress,
            UpdatedAt = DateTimeOffset.Now
        };
        await repository.Update(updatedUser);
        return updatedUser.AsDto();
    }
}