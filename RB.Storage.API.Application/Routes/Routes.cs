using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RB.Storage.Domain.Aggregates.UserAggregates.Entities;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;

namespace RB.Storage.API.Application.Routes;

public static class Routes
{
    public static void MapRoutes(this Microsoft.AspNetCore.Builder.WebApplication app)
    {
        // app.MapGet("/users", UsersEndpoints.GetAll)
        //     .WithOpenApi()
        //     .WithDescription("Get all users")
        //     .Produces<GetAllUsersResponse>(StatusCodes.Status200OK, "application/json")
        //     .Produces(StatusCodes.Status204NoContent, contentType: "application/json")
        //     .WithTags("Users");


        // app.MapPost("/users/add", async ([FromBody] UsersAddRequest request, [FromServices] IUserRepository userRepository, [FromServices] ICryptographyService cryptographyService) =>
        // {
        //     ArgumentNullException.ThrowIfNull(userRepository);
        //     ArgumentNullException.ThrowIfNull(request);
        //     var user = User.CreateNewUser(request.Email, request.Password, cryptographyService);
        //     var result = await userRepository.AddAsync(user);
        //     return result ? Results.Created($"/users/{user.Id}", user) : Results.Conflict("User already exists.");
        // });
    }
}
