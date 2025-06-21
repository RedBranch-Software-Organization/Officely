using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RB.Storage.API.Application.Responses.Users.GetAllUsers;
using MediatR;
using RB.Storage.API.Application.Commands.GetAllUsers;
namespace RB.Storage.API.Application.Endpoints.V1;

public static class UsersEndpoints
{
    public static async Task<IResult> GetAll([FromServices] IMediator mediator)
    {
        var response = await mediator.Send(new GetAllUsersCommand());
        return response is null || response.Users is null || !response.Users.Any()
            ? Results.NoContent()
            : Results.Ok(new GetAllUsersResponse(response));
    }
}
