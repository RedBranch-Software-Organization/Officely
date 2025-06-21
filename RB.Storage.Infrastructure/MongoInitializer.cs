using MongoDB.Driver;
using RB.Storage.Infrastructure.Documents;
using RB.Storage.Infrastructure.Extensions;

namespace RB.Storage.Infrastructure;

public class MongoInitializer
{
    private readonly IMongoDatabase _database;
    public MongoInitializer(IMongoDatabase database)
    {
        _database = database
            ?? throw new ArgumentNullException(nameof(database), "MongoDB database cannot be null.");
    }

    public async Task InitializeAsync()
    {
        await _database.CreateCollectionIfNotExistsAsync(UserDocument.CollectionName);
    }
}
