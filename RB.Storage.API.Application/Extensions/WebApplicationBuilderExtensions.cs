using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace RB.Storage.API.Application.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static async Task RunStorageApiAsync(this WebApplicationBuilder builder, Assembly assembly)
    {
        await builder.Services.AddStorageApiAsync(builder.Configuration, assembly);
        var app = builder.Build();
        app.UseStorageApi();
        await app.RunAsync();
    }
}
