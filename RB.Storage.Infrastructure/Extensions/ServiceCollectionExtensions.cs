using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Infrastructure.Repositories;

namespace RB.Storage.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    private const string RB_STORAGE_DB_NAME = "RBStorageDb";

    public static async Task AddStorageInfrastructurAsync(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoDatabase(configuration);
        await services.InitializeDatabaseAsync();
        services.AddRepositories();
    }

    internal static void AddRepositories(this IServiceCollection services)
        => services.AddTransient<IUserRepository, UserRepository>();


    internal static async Task InitializeDatabaseAsync(this IServiceCollection services)
    {
        var mongoDatabase = services.FirstOrDefault(s => s.ServiceType == typeof(IMongoDatabase))?.ImplementationInstance as IMongoDatabase
            ?? throw new InvalidOperationException("MongoDB database is not registered. Ensure that AddMongoDatabase is called before InitializeDatabase.");
        var initializer = new MongoInitializer(mongoDatabase)
            ?? throw new InvalidOperationException("MongoInitializer could not be created. Ensure that the MongoDB service is registered.");
        await initializer.InitializeAsync();
    }

    internal static void AddMongoDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(RB_STORAGE_DB_NAME);
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException($"Connection string {RB_STORAGE_DB_NAME} is not configured.");

        var client = new MongoClient(connectionString);
        services.AddSingleton(client.GetDatabase(RB_STORAGE_DB_NAME));
    }
}
