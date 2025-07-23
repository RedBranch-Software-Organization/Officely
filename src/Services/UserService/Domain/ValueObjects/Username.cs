using RB.SharedKernel;

namespace Officely.UserService.Domain.ValueObjects;

public class Username : ValueObject
{
    public string Value { get; private set; }

    private Username(string value)
        => Value = value;

    //ToDo: Add validation for username format, length, etc.
    public static Username Initialize(string value)
        => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
