using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RB.SharedKernel.MongoDb.Extensions;

namespace Officely.UserService.Infrastructure.Databases.Officely;

public class OfficelyDb
{
    public static readonly string NAME = "OfficelyDb";
    public readonly IMongoDatabase Database;
    private OfficelyDb(IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString(NAME);
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string " + NAME + " is not configured.");
        }

        MongoClient mongoClient = new MongoClient(connectionString);
        Database = mongoClient.GetDatabase(NAME);
    }

    private async Task InitializeAsync()
        => await Database.CreateCollectionIfNotExistsAsync(Collections.Users.Name);

    public static async Task<OfficelyDb> InitializeAsync(IConfiguration configuration, bool initialize = true)
    {
        var officelyDb = new OfficelyDb(configuration);
        if (initialize)
            await officelyDb.InitializeAsync();

        return officelyDb;
    }
}
