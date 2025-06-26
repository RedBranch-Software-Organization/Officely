using RB.Storage.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RB.Storage.API.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddStorageApiAsync(this IServiceCollection services, IConfiguration configuration)
    {
        await services.AddStorageInfrastructurAsync(configuration);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        services.AddOpenApi("Storage API");
        services.AddApiVersioning();
    }
}

// app.MapPost("/users/add", async ([FromBody] UsersAddRequest request, [FromServices] IUserRepository userRepository, [FromServices] ICryptographyService cryptographyService) =>
// {
//     ArgumentNullException.ThrowIfNull(userRepository);
//     ArgumentNullException.ThrowIfNull(request);
//     var user = User.CreateNewUser(request.Email, request.Password, cryptographyService);
//     var result = await userRepository.AddAsync(user);
//     return result ? Results.Created($"/users/{user.Id}", user) : Results.BadRequest("User already exists.");
// });