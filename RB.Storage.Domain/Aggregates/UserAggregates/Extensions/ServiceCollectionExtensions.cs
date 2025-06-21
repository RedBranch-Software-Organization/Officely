using Microsoft.Extensions.DependencyInjection;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;
using RB.Storage.Domain.Aggregates.UserAggregates.Services;

namespace RB.Storage.Domain.Aggregates.UserAggregates.Extensions;

public static class ServiceCollectionExtensions
{
    internal static void AddUserDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ICryptographyService, CryptographyService>();
    }
}
