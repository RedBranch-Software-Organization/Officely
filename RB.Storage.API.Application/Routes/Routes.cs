using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RB.Storage.API.Application.Endpoints.V1;
using RB.Storage.API.Application.Responses.Users.GetAllUsers;

namespace RB.Storage.API.Application.Routes;

public static class Routes
{
    public static void MapRoutes(this WebApplication app)
    {
        app.MapGet("/users", () => UsersEndpoints.GetAll)
            .WithOpenApi()
            .WithDescription("Get all users")
            .Produces<GetAllUsersResponse>(StatusCodes.Status200OK, "application/json")
            .Produces(StatusCodes.Status204NoContent, contentType: "application/json")
            .WithTags("Users");
    }
}
