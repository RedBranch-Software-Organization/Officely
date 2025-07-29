namespace Officely.UserService.Api.Client.Models.SignUp;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string VerificationCode { get; set; }
}

