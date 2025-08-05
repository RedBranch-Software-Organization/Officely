using MassTransit;
using Microsoft.Extensions.Configuration;
using Officely.IntegrationEvents.Client;
using Officely.StorageService.Domain.Interfaces;

namespace Officely.StorageService.Application.Consumers;

public class ClientRegisteredConsumer(IConfiguration configuration, IStorageItemService storageItemService) : IConsumer<ClientRegisteredIntegrationEvent>
{
    private readonly string _basePath = configuration["StorageRootDirectory"]
        ?? throw new InvalidOperationException("StorageRootDirectory is not configured.");

    public async Task Consume(ConsumeContext<ClientRegisteredIntegrationEvent> context)
    {
        var eventData = context.Message;
        await storageItemService.InitializeClientDirectoryAsync(eventData.UserId, _basePath);
    }
}