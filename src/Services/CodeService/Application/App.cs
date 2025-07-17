using Microsoft.AspNetCore.Builder;
using RB.Storage.CodeService.Application.Extensions;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("RB.Storage.CodeService.Api")]

namespace RB.Storage.CodeService.Application;
internal static class App
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
