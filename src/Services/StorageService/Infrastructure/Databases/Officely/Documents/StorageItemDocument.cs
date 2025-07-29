using MongoDB.Bson.Serialization.Attributes;
using RB.SharedKernel.MongoDb.Interfaces;

namespace Officely.StorageService.Infrastructure.Databases.Officely.Documents;

public class StorageItemDocument : IDocument<string>
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRequired]
    public string Id { get; set; }

    [BsonElement("name")]
    [BsonRequired]
    public string Name { get; set; }

    [BsonElement("authorId")]
    [BsonRequired]
    public string AuthorId { get; set; }

    [BsonElement("type")]
    [BsonRequired]
    public int Type { get; set; }

    [BsonElement("children")]
    public List<StorageItemDocument> Children { get; set; }
}
