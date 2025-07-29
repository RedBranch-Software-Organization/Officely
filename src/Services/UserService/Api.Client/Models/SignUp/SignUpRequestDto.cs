namespace Officely.UserService.Api.Client.Models.SignUp;

public class SignUpRequestDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
