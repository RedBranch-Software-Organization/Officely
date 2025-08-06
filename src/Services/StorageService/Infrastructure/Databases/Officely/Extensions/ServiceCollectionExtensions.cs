using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Officely.StorageService.Domain.Interfaces;
using Officely.StorageService.Infrastructure.Databases.Officely.Repositories;

namespace Officely.StorageService.Infrastructure.Databases.Officely.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddOfficelyDbAsync(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(await OfficelyDb.InitializeAsync(configuration, false));
        services.AddTransient<IStorageItemRepository, StorageItemRepository>();
    }
}
