using Microsoft.Extensions.DependencyInjection;
using Officely.CodeService.Domain.Factories;
using Officely.CodeService.Domain.Interfaces;

namespace Officely.CodeService.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IGeneratorFactory, GeneratorFactory>();
    }
}
