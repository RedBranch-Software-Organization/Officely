using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Officely.UserService.Application.Extensions;

public static class WebApplicationExtensions
{
    public static void UseApplication(this WebApplication app)
    {
         if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Service API V1");
                c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
            });
        }

        app.UseHttpsRedirection();
        app.UseCors();
        app.MapEndpoints();
    }
}
