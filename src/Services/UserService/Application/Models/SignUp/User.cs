namespace Officely.UserService.Application.Models.SignUp;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string VerificationCode { get; set; }
}
