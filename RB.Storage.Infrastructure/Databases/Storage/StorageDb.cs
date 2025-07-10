using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RB.SharedKernel.MongoDb.Extensions;
using RB.Storage.Infrastructure.Databases.Storage.Constants;

namespace RB.Storage.Infrastructure.Databases.Storage;

public class StorageDb
{
    public static readonly string NAME = "StorageDb";
    public readonly IMongoDatabase Database;
    private StorageDb(IConfiguration configuration)
        => Database = configuration.GetMongoDatabase(NAME);

    private async Task InitializeAsync()
        => await Database.CreateCollectionIfNotExistsAsync(CollectionNames.USERS);
        
    public static async Task<StorageDb> InitializeAsync(IConfiguration configuration, bool initialize = true)
    {
        var storageDb = new StorageDb(configuration);
        if (initialize)
            await storageDb.InitializeAsync();

        return storageDb;
    }
}
