using MongoDB.Driver;
using Officely.UserService.Domain.Entities;
using Officely.UserService.Domain.Interfaces;
using Officely.UserService.Infrastructure.Databases.Officely.Documents;
using Officely.UserService.Infrastructure.Databases.Officely.Mappers;
using RB.SharedKernel.MongoDb;

namespace Officely.UserService.Infrastructure.Databases.Officely.Repositories;

public class UserRepository(OfficelyDb db) : RepositoryBase<UserDocument, string>(db.Database), IUserRepository
{
    public override string CollectionName => Collections.Users.Name;

    public async Task<User> AddAsync(User user)
    {
        //ToDo: Something don't work with RepositoryBase<TDocument, TKey> and MongoDB.Driver

        await Database.GetCollection<UserDocument>(CollectionName).InsertOneAsync(UserMapper.MapToDocument(user));
        FilterDefinition<UserDocument> empty = Builders<UserDocument>.Filter.Empty;

        var coll =  await Database.GetCollection<UserDocument>(CollectionName).FindAsync(empty);
        
        return coll.FirstOrDefault() is UserDocument document
            ? UserMapper.MapToDomain(document)
            : throw new InvalidOperationException("No user found after insertion.");
    }
}
