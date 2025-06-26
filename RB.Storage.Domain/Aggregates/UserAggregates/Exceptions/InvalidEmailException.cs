namespace RB.Storage.Domain.Aggregates.UserAggregates.Exceptions;


public class InvalidEmailException(string value) : Exception($"Email: {value} must contain '@'.")
{

}
