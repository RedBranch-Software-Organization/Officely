using Microsoft.AspNetCore.Builder;

namespace UserService.Application.Extensions;

public static class WebApplicationExtensions
{
    public static void UseApplication(this WebApplication app)
    {
        app.MapEndpoints();
    }
}
