using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Officely.CodeService.Api.Client.Extensions;
using Officely.UserService.Infrastructure.Extensions;
using RB.SharedKernel.MediatR.Command;
using RB.SharedKernel.MediatR.Query;

namespace Officely.UserService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static async Task AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //ToDo: Move string values to configuration
        //ToDo: Create exception for missing configuration
        services.AddApiClient(configuration["HttpClients:CodeService"] ?? throw new InvalidOperationException("CodeService base address is not configured."));

        await services.AddInfrastructureAsync(configuration);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ICommandHandler<ICommand>>()
                                    .RegisterServicesFromAssemblyContaining<ICommandHandler<ICommand<ICommandResult>, ICommandResult>>()
                                    .RegisterServicesFromAssemblyContaining<IQueryHandler<IQuery>>()
                                    .RegisterServicesFromAssemblyContaining<IQueryHandler<IQuery<IQueryResult>, IQueryResult>>()
                                    .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );

        services.AddOpenApi();
        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
        services.AddSwaggerGen();
    }
}
