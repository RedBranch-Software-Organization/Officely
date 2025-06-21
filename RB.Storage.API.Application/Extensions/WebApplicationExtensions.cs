using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using RB.Storage.API.Application.Routes;

namespace RB.Storage.API.Application.Extensions;

public static class WebApplicationExtensions
{
    public static void UseStorageApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi(settings =>
            {
                settings.Path = "/swagger";
                settings.DocumentTitle = "RB Storage API Documentation";
            });
            app.MapOpenApi();
        }
        app.UseHttpsRedirection();

        // If API versioning is needed, implement or use a supported package here.
        // var appVersion1 = app.NewVersionedApi();

        app.MapRoutes();
    }
}
