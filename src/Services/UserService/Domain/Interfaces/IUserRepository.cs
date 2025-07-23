using Officely.UserService.Domain.Entities;

namespace Officely.UserService.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
}
