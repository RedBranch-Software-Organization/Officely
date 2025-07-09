using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RB.Storage.Domain.Aggregates.UserAggregates.Exceptions;

[Serializable]
public class EmailNullException() : Exception("Email cannot be null or empty.")
{

    public static void ThrowIfNullOrWhiteSpace(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmailNullException();
    }
}