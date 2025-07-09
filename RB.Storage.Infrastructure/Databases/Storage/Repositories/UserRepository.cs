using MongoDB.Driver;
using RB.Storage.Domain.Aggregates.UserAggregates.Entities;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Infrastructure.Databases.Storage.Collections;
using RB.Storage.Infrastructure.Databases.Storage.Documents;

namespace RB.Storage.Infrastructure.Databases.Storage.Repositories;

public class UserRepository(StorageDb storageDb) : IUserRepository
{
    private readonly StorageDb _storageDb = storageDb;

    public async Task<IList<User>> GetAllAsync()
    {
        var filter = Builders<UserDocument>.Filter.Empty;
        var userDocuments = await _storageDb.Database.GetCollection<UserDocument>(UsersCollection.NAME).Find(filter).ToListAsync();
        return [.. userDocuments.Select(doc => User.Initialize(
            Guid.Parse(doc.Id),
            doc.Email,
            doc.HashedPassword,
            DateTime.ParseExact(doc.CreatedAt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)))];
    }
}
