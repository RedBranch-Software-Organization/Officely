using RB.SharedKernel;

namespace Officely.UserService.Domain.ValueObjects;

public class PasswordHash : ValueObject
{
    public string Value { get; }

    private PasswordHash(string value)
        => Value = value;

    public static PasswordHash Initialize(string hashedPassword)
        => new(hashedPassword);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
