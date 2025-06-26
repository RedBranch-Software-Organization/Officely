using MongoDB.Bson.Serialization.Attributes;

namespace RB.Storage.Infrastructure.Databases.Storage.Documents;

public class UserDocument
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