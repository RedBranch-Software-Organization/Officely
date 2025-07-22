using Microsoft.AspNetCore.Routing;
using Officely.CodeService.Application.Endpoints;

namespace Officely.CodeService.Application.Extensions;
internal static class EnpointRouteBuilderExtensions
{
    internal static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGenerate();
    }
}
