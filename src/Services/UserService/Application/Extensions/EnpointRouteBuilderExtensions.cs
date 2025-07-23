using Microsoft.AspNetCore.Builder;
using UserService.Application.Endpoints;

namespace UserService.Application.Extensions;

public static class EnpointRouteBuilderExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapRegisterEndpoint();
    }
}
