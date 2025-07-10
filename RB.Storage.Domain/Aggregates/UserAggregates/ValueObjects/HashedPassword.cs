using RB.SharedKernel;

namespace RB.Storage.Domain.Aggregates.UserAggregates.ValueObjects;

public class HashedPassword : ValueObject
{
    public string Value { get; }

    private HashedPassword(string value)
        => Value = value;

    public static HashedPassword Initialize(string hashedPassword)
        => new(hashedPassword);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
