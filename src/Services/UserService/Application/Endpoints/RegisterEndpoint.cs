using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RB.SharedKernel.MediatR.Extensions;
using RegisterCommand = Officely.UserService.Application.Commands.Register.Command;
using RegisterResult = Officely.UserService.Application.Commands.Register.Result;
using RegisterValidator = Officely.UserService.Application.Commands.Register.Validator;

namespace Officely.UserService.Application.Endpoints;

public static class RegisterEndpoint
{

    public static void MapRegisterEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", RegisterAsync)
            .Accepts<RegisterCommand>("application/json")
            .WithName("Register User")
            .Produces<RegisterResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Registers a new user with the provided email, password, and username.");
    }
    private static async Task<IResult> RegisterAsync([FromBody] RegisterCommand command, IMediator mediator)
    {
        try
        {
            var validationResult = await new RegisterValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            var result = await mediator.SendCommandAsync(command);
            return Results.Created($"Created user with email {command.Email}", result);
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex.Message);
        }
    }
}
