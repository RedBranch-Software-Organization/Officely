using Microsoft.AspNetCore.Builder;
using Officely.UserService.Application.Extensions;

namespace Officely.UserService.Application;

public static class App
{
    internal static async Task BuildAndRunAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddApplication();
        var app = builder.Build();
        app.UseApplication();
        await app.RunAsync();
    }
}
