using Microsoft.AspNetCore.Builder;
using Officely.UserService.Application.Extensions;

namespace Officely.UserService.Application;

public static class App
{
    public static async Task BuildAndRunAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        await builder.Services.AddApplication(builder.Configuration);
        var app = builder.Build();
        app.UseApplication();
        await app.RunAsync();
    }
}
