using MongoDB.Bson;
using MongoDB.Driver;

namespace RB.Storage.Infrastructure.Extensions;

public static class MongoDatabaseExtensions
{
    //ToDo: Move to RB.SharedKernel
    public static async Task CreateCollectionIfNotExistsAsync(this IMongoDatabase database, string collectionName)
    {
        ArgumentNullException.ThrowIfNull(database);
        if (string.IsNullOrWhiteSpace(collectionName))
            throw new ArgumentException("Collection name cannot be null or empty.", nameof(collectionName));

        var filter = new BsonDocument("name", collectionName);
        var options = new ListCollectionsOptions { Filter = filter };
        var collections = await database.ListCollectionsAsync(options);

        if (!await collections.AnyAsync())
            await database.CreateCollectionAsync(collectionName);
    }
}
