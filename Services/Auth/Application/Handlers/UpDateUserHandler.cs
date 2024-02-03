using Auth.Core;
using MediatR;

namespace Application;

public sealed class UpDateUserHandler(IUserRepository repository)
: IRequestHandler<UpDateUserCommand, UserDTO>
{
  private readonly IUserRepository _repository = repository;
  public async Task<UserDTO?> Handle(UpDateUserCommand request, CancellationToken cancellationToken)
  {
    var user = await _repository.GetById(request.Id);
    if (user != null)
    {
      var updatedUser = await _repository.Update(user with { EmailAddress = request.EmailAddress, UpdatedAt = DateTimeOffset.Now });
      return UserDTO.FromUser(updatedUser);
    }
    return null;
  }
}


