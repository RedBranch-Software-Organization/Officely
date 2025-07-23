namespace Officely.UserService.Domain.Exceptions;

public class InvalidEmailFormatException(string email) : Exception($"Email must contain '@' character. Provided: {email}")
{
    public static void ThrowIfInvalid(string email)
    {
        if (!email.Contains('@'))
            throw new InvalidEmailFormatException(email);
    }
}
