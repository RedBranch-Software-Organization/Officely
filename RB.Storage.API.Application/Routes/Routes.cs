using Microsoft.AspNetCore.Builder;
using RB.Storage.API.Application.Routes.Users;

namespace RB.Storage.API.Application.Routes;

public static class Routes
{
    public static void MapRoutes(this WebApplication app)
    {
        app.MapGetAllUsers();
    }
}
