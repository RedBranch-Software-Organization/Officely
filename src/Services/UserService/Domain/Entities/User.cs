using Officely.UserService.Domain.Enums;
using Officely.UserService.Domain.Interfaces;
using Officely.UserService.Domain.ValueObjects;
using RB.SharedKernel;

namespace Officely.UserService.Domain.Entities;

public class User : Entity<Guid>, IAggregateRoot
{
    public Email Email { get; private set; }
    public HashedPassword PasswordHash { get; private set; }
    public Username Username { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Roles Roles { get; private set; }

    private User(Guid id, Email email, Username username, HashedPassword passwordHash, DateTime createdAt, Roles roles) : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
        Username = username;
        CreatedAt = createdAt;
        Roles = roles;
    }

    public static User Initialize(Guid id, Email email, Username username, HashedPassword passwordHash, DateTime createdAt, Roles roles)
        => new(id, email, username, passwordHash, createdAt, roles);

    public static User CreateClient(string email, string username, string password, IPasswordService passwordService)
        => new(Guid.NewGuid(), Email.Initialize(email), Username.Initialize(username), passwordService.Hash(Password.Initialize(password)), DateTime.UtcNow, Roles.Client);
}
