using MongoDB.Bson.Serialization.Attributes;
using RB.SharedKernel.MongoDb.Interfaces;

namespace Officely.UserService.Infrastructure.Databases.Officely.Documents;

public class UserDocument : IDocument<string>
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRequired]
    public string Id { get; set; }

    [BsonElement("email")]
    [BsonRequired]
    public string Email { get; set; }

    [BsonElement("passwordHash")]
    [BsonRequired]
    public string PasswordHash { get; set; }

    [BsonElement("username")]
    [BsonRequired]
    public string Username { get; set; }

    [BsonElement("createdAt")]
    [BsonRequired]
    public DateTime CreatedAt { get; set; }

    [BsonElement("roles")]
    [BsonRequired]
    public int Roles { get; set; }

    [BsonElement("verificationCode")]
    [BsonRequired]
    public string VerificationCode { get; set; }

    [BsonElement("verificationCodeExpiresAt")]
    [BsonRequired]
    public DateTime VerificationCodeExpiresAt { get; set; }
    
    [BsonElement("verifiedAt")]
    public DateTime? VerifiedAt { get; set; }
}
