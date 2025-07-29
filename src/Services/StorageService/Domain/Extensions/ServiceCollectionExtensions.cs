using System;
using Microsoft.Extensions.DependencyInjection;
using Officely.StorageService.Domain.Interfaces;
using Officely.StorageService.Domain.Services;

namespace Officely.StorageService.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IStorageItemService, StorageItemService>();  
    }
}
