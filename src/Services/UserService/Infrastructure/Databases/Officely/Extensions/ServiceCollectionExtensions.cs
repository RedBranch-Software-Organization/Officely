using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Officely.UserService.Domain.Interfaces;
using Officely.UserService.Infrastructure.Databases.Officely.Repositories;

namespace Officely.UserService.Infrastructure.Databases.Officely.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddOfficelyDbAsync(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(await OfficelyDb.InitializeAsync(configuration, false));
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
