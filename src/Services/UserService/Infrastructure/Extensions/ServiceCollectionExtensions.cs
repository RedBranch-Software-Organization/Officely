using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Officely.UserService.Domain.Interfaces;
using Officely.UserService.Infrastructure.Services;
using Officely.UserService.Infrastructure.Databases.Officely.Extensions;

namespace Officely.UserService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddInfrastructureAsync(this IServiceCollection services, IConfiguration configuration)
    {
        await services.AddOfficelyDbAsync(configuration);
        services.AddTransient<IPasswordService, PasswordService>();
        services.AddTransient<IVerificationCodeGenerator, VerificationCodeGenerator>();
    }
}
