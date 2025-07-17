using Microsoft.AspNetCore.Routing;
using RB.Storage.CodeService.Application.Endpoints;

namespace RB.Storage.CodeService.Application.Extensions;
internal static class EnpointRouteBuilderExtensions
{
    internal static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGenerate();
    }
}
