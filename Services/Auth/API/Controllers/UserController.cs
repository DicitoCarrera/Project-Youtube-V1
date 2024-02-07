using System.Net;
using Application.Commands;
using Application.Queries;
using Application.Responses;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route("[action]/{id}", Name = "GetUserById")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<UserDto>> GetUserById(UserId id)
    {
        var query = new GetUserQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Route("CreateUser")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserCommand userCommand)
    {
        var result = await mediator.Send(userCommand);
        return Ok(result);
    }

    [HttpPut]
    [Route("UpdateUser")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateUser([FromBody] UpDateUserCommand userCommand)
    {
        var result = await mediator.Send(userCommand);
        return Ok(result);
    }
}