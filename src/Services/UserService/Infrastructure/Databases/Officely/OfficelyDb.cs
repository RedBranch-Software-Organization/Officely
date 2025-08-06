using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RB.SharedKernel.MongoDb.Extensions;

namespace Officely.UserService.Infrastructure.Databases.Officely;

public class OfficelyDb
{
    public static readonly string NAME = "OfficelyDb";
    public readonly IMongoDatabase Database;
    //ToDo: Remove using in line with MongoClient from GetMongoDatabase in RB.SharedKernel.MongoDb.Extensions.ConfigurationExtensions
    private OfficelyDb(IConfiguration configuration)
    {
        var officelyDbConnectionString = configuration.GetSection("MongoDbConnectionStrings").GetSection(NAME);
        string? connectionString = officelyDbConnectionString["ConnectionString"];
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string " + NAME + " is not configured.");

        MongoClient mongoClient = new(connectionString);
        Database = mongoClient.GetDatabase(officelyDbConnectionString["DbName"]);
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
