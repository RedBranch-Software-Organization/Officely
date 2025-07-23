using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Extensions;

namespace UserService.Application;

public static class App
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddApplication();
        return services;
    }

    public static void UseApplication(this WebApplication app)
    {
        app.UseApplication();
    }
}
