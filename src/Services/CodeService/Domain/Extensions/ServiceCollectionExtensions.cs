using Microsoft.Extensions.DependencyInjection;
using RB.Storage.CodeService.Domain.Factories;
using RB.Storage.CodeService.Domain.Interfaces;

namespace RB.Storage.CodeService.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCodeService(this IServiceCollection services)
    {
        services.AddScoped<IGeneratorFactory, GeneratorFactory>();
    }
}
