using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RB.Storage.API.Application.Responses.Users.GetAllUsers;
using MediatR;
using RB.Storage.API.Application.Commands.GetAllUsers;
namespace RB.Storage.API.Application.Functions;

public static class UsersFunctions
{
    public static async Task<IResult> GetAll([FromServices] IMediator mediator)
    {
            var response = await mediator.Send(new GetAllUsersCommand());
            return response is null || response.Users is null || !response.Users.Any()
                ? Results.NotFound("No users found.")
                : Results.Ok(new GetAllUserResponse(response));
    }
}
