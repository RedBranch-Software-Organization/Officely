using RB.SharedKernel;

namespace Officely.UserService.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    private Email(string value)
        => Value = value;

    //ToDo: Add validation for email format, length, etc.
    public static Email Initialize(string email)
        => new(email);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}