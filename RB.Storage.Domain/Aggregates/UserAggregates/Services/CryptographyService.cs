using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
namespace RB.Storage.Domain.Aggregates.UserAggregates.Services;

public class CryptographyService : ICryptographyService
{
    public string HashPassword(string password)
        => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool VerifyPassword(string password, string hashedPassword)
        => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
