using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UserService.Application.Commands.Register;

namespace UserService.Application.Endpoints;

public static class RegisterEndpoint
{
    public static void MapRegisterEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (IMediator mediator, RegisterCommand command) =>
        {
            await mediator.Send(command);
            return Results.Ok();
        });
    }
}
