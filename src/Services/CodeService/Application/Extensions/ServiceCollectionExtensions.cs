using Microsoft.Extensions.DependencyInjection;
using RB.SharedKernel.MediatR.Extensions;
using RB.Storage.CodeService.Domain.Extensions;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddCodeService();
        services.AddSharedKernelMediatR();
    }
}
