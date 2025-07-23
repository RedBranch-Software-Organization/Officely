namespace Officely.UserService.Domain.ValueObjects;

public class VerificationCode
{
    public string Value { get; private set; }
    public DateTime VerificationCodeExpiresAt { get; private set; }
    public DateTime? VerifiedAt { get; private set; }

    public bool IsExpired => DateTime.UtcNow > VerificationCodeExpiresAt;
    public bool IsVerified => VerifiedAt.HasValue && VerifiedAt.Value <= DateTime.UtcNow;

    private VerificationCode(string value, DateTime expiresAt, DateTime? verifiedAt)
    {
        Value = value;
        VerificationCodeExpiresAt = expiresAt;
        VerifiedAt = verifiedAt;
    }

    public static VerificationCode Create(string value, int verificationCodeExpirationMinutes)
        => new(value, DateTime.UtcNow.AddMinutes(verificationCodeExpirationMinutes), null);

    public static VerificationCode Initialize(string value, DateTime expiresAt, DateTime? verifiedAt)
        => new(value, expiresAt, verifiedAt);
}
