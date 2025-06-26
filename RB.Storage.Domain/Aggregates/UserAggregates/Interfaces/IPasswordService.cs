using RB.Storage.Domain.Aggregates.UserAggregates.ValueObjects;

namespace RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;

public interface IPasswordService
{
    HashedPassword Hash(Password password);
    PasswordVerifyResult Verify(Password password, HashedPassword hashedPassword);
}
