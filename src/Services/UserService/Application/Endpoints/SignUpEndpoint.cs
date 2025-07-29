using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RB.SharedKernel.MediatR.Extensions;
using SignUpCommand = Officely.UserService.Application.Commands.SignUp.Command;
using SignUpResult = Officely.UserService.Application.Commands.SignUp.Result;
using SignUpValidator = Officely.UserService.Application.Commands.SignUp.Validator;

namespace Officely.UserService.Application.Endpoints;

public static class SignUpEndpoint
{

    public static void MapSignUpEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/signup", SignUpAsync)
            .Accepts<SignUpCommand>("application/json")
            .WithName("Sign Up User")
            .Produces<SignUpResult>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Sign up a new user with the provided email, password, and username.");
    }
    private static async Task<IResult> SignUpAsync([FromBody] SignUpCommand command, IMediator mediator)
    {
        try
        {
            var validationResult = await new SignUpValidator().ValidateAsync(command);
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
