using Application.Commands.Register;
using Application.Queries.Login;
using MediatR;

namespace API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost(pattern: "auth/register",
            handler: async (RegisterCommand command, ISender mediator) =>
            {
                var result = await mediator.Send(request: command);
                return Results.Ok(value: result);
            }
        );

        app.MapPost(pattern: "auth/login",
            handler: async (LoginQuery query, ISender mediator) =>
            {
                var result = await mediator.Send(request: query);
                return Results.Ok(value: result);
            }
        );
    }
}