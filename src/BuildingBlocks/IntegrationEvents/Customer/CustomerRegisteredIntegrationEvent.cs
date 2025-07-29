namespace IntegrationEvents.Customer;

public record CustomerRegisteredIntegrationEvent(Guid UserId, string Email, string VerificationCode);