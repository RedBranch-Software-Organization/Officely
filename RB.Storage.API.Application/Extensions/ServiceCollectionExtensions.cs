using System.Reflection;
using MediatR;
using RB.Storage.Domain.Extensions;
using RB.Storage.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RB.Storage.API.Application.Commands.GetAllUsers;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;


namespace RB.Storage.API.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddStorageApiApplication(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IRequestHandler<GetAllUsersCommand, GetAllUsersCommandResponse>, GetAllUsersCommandHanler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }

    public static async Task AddStorageApiAsync(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddOpenApiDocument(config =>
        {
            config.Title = "RB Storage API";
            config.Version = "v1.0";
            config.Description = "API for managing storage operations.";
            config.DocumentName = "RBStorageApi";
        });
        services.AddStorageDomain();
        await services.AddStorageInfrastructurAsync(configuration);
        services.AddStorageApiApplication(assembly);
        services.AddProblemDetails();
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