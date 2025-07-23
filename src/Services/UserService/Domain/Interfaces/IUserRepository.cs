using Officely.UserService.Domain.Entities;

namespace Officely.UserService.Domain.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
}
