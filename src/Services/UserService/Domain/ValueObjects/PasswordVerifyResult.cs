using RB.SharedKernel;
namespace Officely.UserService.Domain.ValueObjects;

public class PasswordVerifyResult : ValueObject
{
    public bool Value { get; }

    private PasswordVerifyResult(bool value)
        => Value = value;

    public static PasswordVerifyResult Initialize(bool value)
        => new(value);

    public static PasswordVerifyResult Matched
        => new(true);

    public static PasswordVerifyResult NotMatched
        => new(!Matched.Value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}