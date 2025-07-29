using Microsoft.AspNetCore.Routing;
using Officely.UserService.Application.Endpoints;

namespace Officely.UserService.Application.Extensions;

public static class EnpointRouteBuilderExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapSignUpEndpoint();
    }
}
