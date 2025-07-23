using RB.SharedKernel;

namespace Officely.UserService.Domain.ValueObjects;

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
