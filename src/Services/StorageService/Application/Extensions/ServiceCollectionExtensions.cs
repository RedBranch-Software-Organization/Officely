using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Officely.StorageService.Application.Consumers;

namespace Officely.StorageService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<CustomerRegisteredConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost:5672", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("customer-registered-consumer", e =>
                {
                    e.ConfigureConsumer<CustomerRegisteredConsumer>(context);
                });
            });
        });
    }
}
