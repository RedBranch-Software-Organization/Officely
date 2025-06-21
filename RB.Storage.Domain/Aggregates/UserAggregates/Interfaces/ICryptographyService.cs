namespace RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;

public interface ICryptographyService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
