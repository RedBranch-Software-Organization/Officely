using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using RB.Storage.API.Application.Routes;

namespace RB.Storage.API.Application.Extensions;

public static class WebApplicationExtensions
{
    public static void UseStorageApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.MapOpenApi();
        app.UseHttpsRedirection();
        app.MapRoutes();
    }
}
