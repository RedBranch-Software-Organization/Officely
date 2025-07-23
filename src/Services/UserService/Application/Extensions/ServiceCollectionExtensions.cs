using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RB.SharedKernel.MediatR.Command;
using RB.SharedKernel.MediatR.Query;

namespace Officely.UserService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
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
