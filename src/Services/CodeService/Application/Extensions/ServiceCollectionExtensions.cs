using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RB.SharedKernel.MediatR.Command;
using RB.SharedKernel.MediatR.Query;
using RB.Storage.CodeService.Domain.Extensions;

namespace RB.Storage.CodeService.Application.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddApplication(this IServiceCollection services)
    {
        services.AddDomain();
        //ToDo: This should be moved to RB.SharedKernel.MediatR.Extensions but it's not working there
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
