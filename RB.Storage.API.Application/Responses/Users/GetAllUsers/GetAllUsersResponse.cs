using RB.Storage.API.Application.Commands.GetAllUsers;

namespace RB.Storage.API.Application.Responses.Users.GetAllUsers
{
    public class GetAllUsersResponse(GetAllUsersCommandResponse response)
    {
        public IList<UserResponse> Users { get; set; } = [.. response.Users.Select(user => new UserResponse(user.Id, user.Email, user.CreatedAt))];
    }
}