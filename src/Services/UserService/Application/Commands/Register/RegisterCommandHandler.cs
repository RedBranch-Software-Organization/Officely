using MediatR;

namespace UserService.Application.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    public Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implement registration logic here
        return Task.FromResult(Unit.Value);
    }
}
