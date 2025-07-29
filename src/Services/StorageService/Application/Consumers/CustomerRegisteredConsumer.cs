using IntegrationEvents.Customer;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Officely.StorageService.Domain.Interfaces;

namespace Officely.StorageService.Application.Consumers;

public class CustomerRegisteredConsumer(IConfiguration configuration, IStorageItemService storageItemService) : IConsumer<CustomerRegisteredIntegrationEvent>
{
    private readonly string _basePath = configuration["StorageRootDirectory"]
        ?? throw new InvalidOperationException("StorageRootDirectory is not configured.");

    public async Task Consume(ConsumeContext<CustomerRegisteredIntegrationEvent> context)
    {
        var eventData = context.Message;
        await storageItemService.InitializeCustomerDirectoryAsync(eventData.UserId, _basePath);
    }
}