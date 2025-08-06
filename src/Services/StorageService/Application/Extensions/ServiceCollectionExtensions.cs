using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Officely.StorageService.Application.Consumers;
using Officely.StorageService.Infrastructure.Extensions;

namespace Officely.StorageService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddApplicationAsync(this IServiceCollection services, IConfiguration configuration)
    {
        await services.AddInfrastructureAsync(configuration);
        //services.AddTransient<IConsumer, ClientRegisteredConsumer>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ClientRegisteredConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("Client-registered-consumer", e =>
                {
                    e.ConfigureConsumer<ClientRegisteredConsumer>(context);
                });
            });
        });
    }
}
