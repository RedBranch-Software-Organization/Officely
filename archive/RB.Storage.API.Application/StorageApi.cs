using Microsoft.AspNetCore.Builder;
using RB.Storage.API.Application.Extensions;

namespace RB.Storage.API.Application;

public static class StorageApi
{
    public static async Task<WebApplication> BuildAsync()
    {
        var builder = WebApplication.CreateBuilder();
        await builder.Services.AddStorageApiAsync(builder.Configuration);
        return builder.Build();
    }
}
