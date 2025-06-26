namespace RB.Storage.Domain.Aggregates.UserAggregates.ValueObjects;

public class HashedPassword
{
    public string Value { get; }

    private HashedPassword(string value)
        => Value = value;

    public static HashedPassword Initialize(string hashedPassword)
        => new(hashedPassword);
}
