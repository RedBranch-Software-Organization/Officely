using Microsoft.AspNetCore.Builder;
using RB.Storage.API.Application.Functions;

namespace RB.Storage.API.Application.Routes.Users;

public static class GetAllRoute
{
    public const string GetAll = $"/users";
    public static RouteHandlerBuilder MapGetAllUsers(this WebApplication app)
        => app.MapGet(GetAll, UsersFunctions.GetAll);
}
