using Application.Queries;
using Application.Responces;
using Core.Repository;
using MediatR;

namespace Application.Handlers;

public sealed class GetUserHandler(IUserRepository repository) : IRequestHandler<GetUserQuery, UserDTO?>
{
    public async Task<UserDTO?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(request.Id);
        if (user != null) return UserDTO.FromUser(user);
        return null;
    }
}