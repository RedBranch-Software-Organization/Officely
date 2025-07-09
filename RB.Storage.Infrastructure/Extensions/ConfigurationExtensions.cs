using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace RB.Storage.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    //ToDo: Move to RB.SharedKernel
    public static IMongoDatabase GetMongoDatabase(this IConfiguration configuration, string name)
    {
        var connectionString = configuration.GetConnectionString(name);
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException($"Connection string {name} is not configured.");

        using var client = new MongoClient(connectionString);
        return client.GetDatabase(name);
    }
}
