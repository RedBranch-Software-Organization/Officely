using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RB.Storage.Domain.Aggregates.UserAggregates.Exceptions;

[Serializable]
public class EmailNullException(string paramName) : ArgumentNullException(paramName, "Email cannot be null or empty.")
{

}