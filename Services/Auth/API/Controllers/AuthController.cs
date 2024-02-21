using Application.Commands;
using Application.Commands.Register;
using Application.Queries;
using Application.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(ISender mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await mediator.Send(command);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(LoginUserQuery query)
    {
        var result = await mediator.Send(query);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }
}