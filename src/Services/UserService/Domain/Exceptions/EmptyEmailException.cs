namespace Officely.UserService.Domain.Exceptions;

public class EmptyEmailException() : Exception("Email cannot be null or empty.")
{
    public static void ThrowIfEmpty(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new EmptyEmailException();
    }
}
