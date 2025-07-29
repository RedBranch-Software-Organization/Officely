

using Officely.StorageService.Domain.Interfaces;
using Officely.StorageService.Domain.Entities;
using Officely.StorageService.Infrastructure.Databases.Officely.Documents;
using RB.SharedKernel.MongoDb;
using MongoDB.Bson;
using MongoDB.Driver;
using Officely.StorageService.Infrastructure.Databases.Officely.Mappers;

namespace Officely.StorageService.Infrastructure.Databases.Officely.Repositories;

public class StorageItemRepository(OfficelyDb db) : RepositoryBase<StorageItemDocument, string>(db.Database), IStorageItemRepository
{
    public override string CollectionName => Collections.StorageItems.Name;

    public async Task<StorageItem> AddAsync(StorageItem storageItem)
    {
        //ToDo: Something don't work with RepositoryBase<TDocument, TKey> and MongoDB.Driver

        await Database.GetCollection<StorageItemDocument>(CollectionName).InsertOneAsync(StorageItemMapper.MapToDocument(storageItem));
        FilterDefinition<StorageItemDocument> empty = Builders<StorageItemDocument>.Filter.Empty;

        var coll =  await Database.GetCollection<StorageItemDocument>(CollectionName).FindAsync(empty);
        return StorageItemMapper.MapToDomain(await coll.FirstOrDefaultAsync());
    }


    private async Task<string?> GetByIdAsync(string id)
    {
        var collection = Database.GetCollection<BsonDocument>(Collections.StorageItems.Name);
        var pipeline = new[]
        {
            new BsonDocument("$unwind", "$Children"),
            new BsonDocument("$match", new BsonDocument("Children.Id", id)),
            new BsonDocument("$project", new BsonDocument
            {
                { "ParentId", "$Id" },
                { "Child", "$Children" }
            })
        };
        var result = await collection.Aggregate<BsonDocument>(pipeline).FirstOrDefaultAsync();
        if (result != null)
        {
            var parentId = result["ParentId"].AsString;
            return parentId;
        }
        else
        {
            return null;
        }
    }
}
