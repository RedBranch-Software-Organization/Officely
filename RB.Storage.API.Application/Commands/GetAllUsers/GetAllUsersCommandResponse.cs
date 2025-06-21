using RB.Storage.Domain.Aggregates.UserAggregates.Entities;

namespace RB.Storage.API.Application.Commands.GetAllUsers;

public class GetAllUsersCommandResponse(IList<User> users)
{
    public IList<User> Users { get; } = users;
}
