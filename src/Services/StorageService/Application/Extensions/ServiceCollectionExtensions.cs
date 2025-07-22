using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RB.SharedKernel.MediatR.Command;
using RB.SharedKernel.MediatR.Query;

namespace Officely.StorageService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        //ToDo: This should be moved to RB.SharedKernel.MediatR.Extensions but it's not working there
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ICommandHandler<ICommand>>()
                                      .RegisterServicesFromAssemblyContaining<ICommandHandler<ICommand<ICommandResult>, ICommandResult>>()
                                      .RegisterServicesFromAssemblyContaining<IQueryHandler<IQuery>>()
                                      .RegisterServicesFromAssemblyContaining<IQueryHandler<IQuery<IQueryResult>, IQueryResult>>()
                                      .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
    }
}
