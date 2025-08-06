namespace Officely.IntegrationEvents.Client;

public record ClientRegisteredIntegrationEvent(Guid UserId, string Email, string VerificationCode);