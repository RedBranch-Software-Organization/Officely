using RB.Storage.Domain.Aggregates.UserAggregates.Entities;
namespace RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;

public interface IUserRepository
{
    Task<bool> AddAsync(User user);
    Task<IList<User>> GetAllAsync();
}
