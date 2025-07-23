using RB.SharedKernel.MediatR.Command;

namespace Officely.UserService.Application.Commands.Register;

public class Handler : ICommandHandler<Command>
{
    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        // TODO: Implement registration logic here
        await Task.CompletedTask;
    }
}
