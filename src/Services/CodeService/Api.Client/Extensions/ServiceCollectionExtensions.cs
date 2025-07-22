using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Officely.CodeService.Api.Client.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApiClient(this IServiceCollection services, string uri)
    {
        services.AddRefitClient<ICodeService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(uri));
    }
}
