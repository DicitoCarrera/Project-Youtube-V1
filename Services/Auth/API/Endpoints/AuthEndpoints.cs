using Application.Commands.Register;
using Application.Queries.Login;
using MediatR;

namespace API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("auth/register",
            async (RegisterCommand command, ISender mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            }
        );

        app.MapPost("auth/login",
            async (LoginQuery query, ISender mediator) =>
            {
                var result = await mediator.Send(query);
                return Results.Ok(result);
            }
        );
    }
}