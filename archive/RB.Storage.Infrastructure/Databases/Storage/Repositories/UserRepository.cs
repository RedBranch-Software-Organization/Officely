using MongoDB.Driver;
using RB.SharedKernel.MongoDb;
using RB.Storage.Domain.Aggregates.UserAggregates.Entities;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Infrastructure.Databases.Storage.Constants;
using RB.Storage.Infrastructure.Databases.Storage.Documents;

namespace RB.Storage.Infrastructure.Databases.Storage.Repositories;

public class UserRepository(StorageDb storageDb) : RepositoryBase<UserDocument, string>(storageDb.Database), IUserRepository
{
    public override string CollectionName => CollectionNames.USERS;

    public async Task<IList<User>> GetAllAsync()
        => [.. (await base.GetAllAsync()).Select(doc => User.Initialize(
            Guid.Parse(doc.Id),
            doc.Email,
            doc.HashedPassword,
            DateTime.ParseExact(doc.CreatedAt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)))];
}
