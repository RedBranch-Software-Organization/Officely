using MongoDB.Bson.Serialization.Attributes;

namespace RB.Storage.Infrastructure.Documents;

public class UserDocument
{
    public static readonly string CollectionName = "users";

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
