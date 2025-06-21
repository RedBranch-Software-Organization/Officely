using Microsoft.Extensions.Configuration;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;

namespace RB.Storage.Domain.Aggregates.UserAggregates.Entities;

public class User
{
    public Guid Id { get; }
    public string Email { get; }
    public string HashedPassword { get; }
    public DateTime CreatedAt { get; }

    private User(Guid id, string email, string hashedPassword, DateTime createdAt)
    {
        Id = id;
        Email = email;
        HashedPassword = hashedPassword;
        CreatedAt = createdAt;
    }

    public static User CreateNewUser(string email, string password, ICryptographyService cryptographyService, IConfiguration? configuration = null)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));
        if (!email.Contains("@"))
            throw new ArgumentException("Email must contain '@'.", nameof(email));
        if (password.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters long.", nameof(password));

        var hashedPassword = cryptographyService.HashPassword(password);
        return new(Guid.NewGuid(), email, hashedPassword, DateTime.UtcNow);
    }

    public static User Initialize(Guid id, string email, string hashedPassword, DateTime createdAt)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        if (string.IsNullOrWhiteSpace(hashedPassword))
            throw new ArgumentException("Hashed password cannot be null or empty.", nameof(hashedPassword));

        return new User(id, email, hashedPassword, createdAt);
    }

    //??
    protected User() { }
}
