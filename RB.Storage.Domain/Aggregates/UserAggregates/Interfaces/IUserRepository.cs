using RB.Storage.Domain.Aggregates.UserAggregates.Entities;
namespace RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;

public interface IUserRepository
{
    Task<IList<User>> GetAllAsync();
}
