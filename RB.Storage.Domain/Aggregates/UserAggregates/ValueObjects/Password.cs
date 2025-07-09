using RB.SharedKernel;

namespace RB.Storage.Domain.Aggregates.UserAggregates.ValueObjects;

public class Password : ValueObject
{
    private static char[] _signs => "`~!@#$%^&*()-_=+[{]};:'\"\\|<,>.?/".ToCharArray();
    private static char[] _digits => "1234567890".ToCharArray();
    private static char[] _lowerLetters => "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
    private static char[] _upperLetters => _lowerLetters.ToString()!.ToUpper().ToCharArray();
    private const int INDEX_WHEN_NOT_EXIST = -1;

    public string Value { get; }

    private Password(string value)
        => Value = value;

    public static Password Initialize(string value)
    {
        Validate(value);
        return new(value);
    }

    private static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password cannot be null or empty.", nameof(value));
        if (value.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters long.", nameof(value));

        if (value.IndexOfAny(_signs).Equals(INDEX_WHEN_NOT_EXIST))
            throw new ArgumentException("Password must contain at least 1 special character.", nameof(value));

        if (value.IndexOfAny(_digits).Equals(INDEX_WHEN_NOT_EXIST))
            throw new ArgumentException("Password must contain at least 1 digit.", nameof(value));

        if (value.IndexOfAny(_lowerLetters).Equals(INDEX_WHEN_NOT_EXIST))
            throw new ArgumentException("Password must contain at least 1 lower letter.", nameof(value));

        if (value.IndexOfAny(_upperLetters).Equals(INDEX_WHEN_NOT_EXIST))
            throw new ArgumentException("Password must contain at least 1 upper letter.", nameof(value));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
