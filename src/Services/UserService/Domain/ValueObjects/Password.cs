using RB.SharedKernel;

namespace Officely.UserService.Domain.ValueObjects;

public class Password : ValueObject
{
    public string Value { get; private set; }

    private Password(string value)
        => Value = value;

    //ToDo: Add validation for password strength, length, etc.
    public static Password Initialize(string value)
        => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
