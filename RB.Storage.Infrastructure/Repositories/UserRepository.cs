using MongoDB.Bson;
using MongoDB.Driver;
using RB.Storage.Domain.Aggregates.UserAggregates.Entities;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Infrastructure.Documents;

namespace RB.Storage.Infrastructure.Repositories;

public class UserRepository(IMongoDatabase database) : IUserRepository
{
    private readonly IMongoDatabase _database = database
            ?? throw new ArgumentNullException(nameof(database));

    public async Task<bool> AddAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        var filter = Builders<UserDocument>.Filter.Eq(doc => doc.Email, user.Email);

        var userDocument = await _database.GetCollection<UserDocument>(UserDocument.CollectionName).FindAsync(filter).Result.FirstOrDefaultAsync();
        if (userDocument != null)
            return false;

        await _database.GetCollection<UserDocument>(UserDocument.CollectionName)
                                .InsertOneAsync(new UserDocument
                                {
                                    Id = user.Id.ToString(),
                                    Email = user.Email,
                                    HashedPassword = user.HashedPassword,
                                    CreatedAt = user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
                                });
        return true;
    }

    public async Task<IList<User>> GetAllAsync()
    {
        var filter = Builders<UserDocument>.Filter.Empty;
        var userDocuments = await _database.GetCollection<UserDocument>(UserDocument.CollectionName).Find(filter).ToListAsync();
        return [.. userDocuments.Select(doc => User.Initialize(
            Guid.Parse(doc.Id),
            doc.Email,
            doc.HashedPassword,
            DateTime.ParseExact(doc.CreatedAt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)))];
    }
}
