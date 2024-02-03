using Auth.Core;
using MediatR;

namespace Application;

internal sealed class CreateUserHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, UserDTO>
{
  private readonly IUserRepository _repository = repository;

  public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
  {
    var hashedPassword = request.Password;

    var user = await _repository.Create(
      User.NewUser(
      request.UserName,
      request.EmailAddress,
      hashedPassword,
      DateTimeOffset.Now
      )
    );

    return UserDTO.FromUser(user);
  }
}

