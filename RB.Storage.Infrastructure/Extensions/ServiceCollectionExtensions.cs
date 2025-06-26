using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Infrastructure.Databases.Storage.Extensions;
using RB.Storage.Infrastructure.Services;

namespace RB.Storage.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddStorageInfrastructurAsync(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        await services.AddStorageDb(configuration);
    }

    private static void AddServices(this IServiceCollection services)
        => services.AddTransient<IPasswordService, PasswordService>();
}
