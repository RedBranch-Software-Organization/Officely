using RB.Storage.Domain.Aggregates.UserAggregates.Exceptions;

namespace RB.Storage.Domain.Aggregates.UserAggregates.ValueObjects;

public class Email
{
    public string Value { get; }

    private Email(string value)
        => Value = value;

    public static Email Initialize(string value)
    {
        Validate(value);
        return new(value);
    }

    private static void Validate(string value)
    {
        EmailNullException.ThrowIfNull(value);
        if (!value.Contains('@'))
            throw new ArgumentException("Email must contain '@'.", nameof(value));
    }
}
