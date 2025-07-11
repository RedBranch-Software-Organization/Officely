using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Infrastructure.Databases.Storage.Repositories;

namespace RB.Storage.Infrastructure.Databases.Storage.Extensions;

internal static class ServiceCollectionExtensions
{
    private static void AddRepositories(this IServiceCollection services)
        => services.AddTransient<IUserRepository, UserRepository>();

    internal static async Task AddStorageDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(await StorageDb.InitializeAsync(configuration, true));
        services.AddRepositories();
    }
}
