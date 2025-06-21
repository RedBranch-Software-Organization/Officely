namespace RB.Storage.API.Application.Responses.Users.GetAllUsers;

public class UserResponse(Guid id, string email, DateTime createdAt)
{
    public Guid Id { get; set; } = id;
    public string Email { get; set; } = email;
    public DateTime CreatedAt { get; set; } = createdAt;
}
