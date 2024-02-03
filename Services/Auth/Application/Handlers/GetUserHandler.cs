using Auth.Core;
using MediatR;

namespace Application;

public sealed class GetUserHandler(IUserRepository repository) : IRequestHandler<GetUserQuery, UserDTO?>
{
  private readonly IUserRepository _repository = repository;
  public async Task<UserDTO?> Handle(GetUserQuery request, CancellationToken cancellationToken)
  {
    var user = await _repository.GetById(request.Id);
    if (user != null)
    {
      return UserDTO.FromUser(user);
    }
    return null;
  }
}
