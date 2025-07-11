using RB.SharedKernel;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Domain.Aggregates.UserAggregates.ValueObjects;

namespace RB.Storage.Domain.Aggregates.UserAggregates.Entities;

public class User : Entity<Guid>, IAggregateRoot
{
    public Email Email { get; }
    public HashedPassword HashedPassword { get; }
    public DateTime CreatedAt { get; }

    private User(Guid id, Email email, HashedPassword hashedPassword, DateTime createdAt) : base(id)
    {
        Email = email;
        HashedPassword = hashedPassword;
        CreatedAt = createdAt;
    }

    public static User Register(string userEmail, string userPassword, IPasswordService passwordService)
        => new(Guid.NewGuid(), Email.Initialize(userEmail), passwordService.Hash(Password.Initialize(userPassword)), DateTime.UtcNow);

    public static User Initialize(Guid id, string emailAddress, string password, DateTime createdAt)
        => new(id, Email.Initialize(emailAddress), HashedPassword.Initialize(password), createdAt);
}
