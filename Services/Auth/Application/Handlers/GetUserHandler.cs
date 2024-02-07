using Application.Queries;
using Application.Responses;
using Core.Repository;
using MediatR;

namespace Application.Handlers;

// Correctly implement the class with inheritance and constructor
public sealed class GetUserHandler(IUserRepository repository) 
    : IRequestHandler<GetUserQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(request.Id);

        return user?.AsDto();
    }
}