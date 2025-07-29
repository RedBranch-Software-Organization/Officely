using System.Threading.Tasks;
using Officely.UserService.Domain.Enums;
using Officely.UserService.Domain.Interfaces;
using Officely.UserService.Domain.ValueObjects;
using RB.SharedKernel;

namespace Officely.UserService.Domain.Entities;

public class User : Entity<Guid>, IAggregateRoot
{
    public Email Email { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public Username Username { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Roles Roles { get; private set; }
    public VerificationCode VerificationCode { get; private set; }

    private User(Guid id, Email email, Username username, PasswordHash passwordHash, DateTime createdAt, Roles roles, VerificationCode verificationCode) : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
        Username = username;
        CreatedAt = createdAt;
        VerificationCode = verificationCode;
        Roles = roles;
    }

    public static User Initialize(Guid id, Email email, Username username, PasswordHash passwordHash, DateTime createdAt, Roles roles, VerificationCode verificationCode)
        => new(id, email, username, passwordHash, createdAt, roles, verificationCode);


    //ToDo: Verification code generation and expiration logic should be handled in a service or factory.
    //We should create ICodeGenerationService and call to microservice to generate the code. Temporarily using empty string and 1 day expiration.
    public static async Task<User> CreateCustomerAsync(string email, string username, string password, IPasswordService passwordService, IVerificationCodeGenerator verificationCodeGenerator)
        => new(Guid.NewGuid(), Email.Initialize(email), Username.Initialize(username), passwordService.Hash(Password.Initialize(password)), DateTime.UtcNow, Roles.Client, await verificationCodeGenerator.GenerateAsync());

}
