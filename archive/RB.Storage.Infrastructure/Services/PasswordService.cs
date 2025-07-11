using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Domain.Aggregates.UserAggregates.ValueObjects;

namespace RB.Storage.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public HashedPassword Hash(Password password)
        => HashedPassword.Initialize(BCrypt.Net.BCrypt.EnhancedHashPassword(password.Value, BCrypt.Net.HashType.SHA512));

    public PasswordVerifyResult Verify(Password password, HashedPassword hashedPassword)
        => PasswordVerifyResult.Initialize(BCrypt.Net.BCrypt.EnhancedVerify(password.Value, hashedPassword.Value, BCrypt.Net.HashType.SHA512));
}
