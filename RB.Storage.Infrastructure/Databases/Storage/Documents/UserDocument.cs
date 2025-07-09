using MongoDB.Bson.Serialization.Attributes;
using RB.SharedKernel.MongoDb.Interfaces;

namespace RB.Storage.Infrastructure.Databases.Storage.Documents;

public class UserDocument : IDocument<string>
{
    [BsonId]
    [BsonElement("id")]
    public string Id { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("hashedPassword")]
    public string HashedPassword { get; set; }

    [BsonElement("createdAt")]
    public string CreatedAt { get; set; }
}