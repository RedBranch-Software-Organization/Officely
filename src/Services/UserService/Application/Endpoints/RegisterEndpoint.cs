using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RB.SharedKernel.MediatR.Extensions;
using RegisterCommand = Officely.UserService.Application.Commands.Register.Command;

namespace Officely.UserService.Application.Endpoints;

public static class RegisterEndpoint
{
    public static void MapRegisterEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async ([AsParameters] RegisterCommand command, IMediator mediator) =>
        {
            await mediator.SendCommandAsync(command);
            return Results.Ok();
        });
    }
}
