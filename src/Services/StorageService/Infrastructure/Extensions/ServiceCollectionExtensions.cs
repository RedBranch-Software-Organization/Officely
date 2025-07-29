using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Officely.StorageService.Domain.Interfaces;
using Officely.StorageService.Infrastructure.Services;

namespace Officely.StorageService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddInfrastructureAsync(this IServiceCollection services, IConfiguration configuration)
    {
        // await services.AddOfficelyDbAsync(configuration);
        services.AddTransient<IDirectoryService, DirectoryService>();
    }
}
