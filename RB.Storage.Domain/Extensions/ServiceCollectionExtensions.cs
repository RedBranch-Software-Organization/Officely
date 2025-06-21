using Microsoft.Extensions.DependencyInjection;
using RB.Storage.Domain.Aggregates.UserAggregates.Extensions;

namespace RB.Storage.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddStorageDomain(this IServiceCollection services)
    {
        services.AddUserDomainServices();
    }
}
