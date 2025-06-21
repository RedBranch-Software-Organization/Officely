using MediatR;
using RB.Storage.Domain.Aggregates.UserAggregates.Interfaces;

namespace RB.Storage.API.Application.Commands.GetAllUsers;

public class GetAllUsersCommandHanler(IUserRepository userRepository) : IRequestHandler<GetAllUsersCommand, GetAllUsersCommandResponse>
{
    private readonly IUserRepository _userRepository = userRepository
        ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task<GetAllUsersCommandResponse> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        cancellationToken.ThrowIfCancellationRequested();
        return new GetAllUsersCommandResponse(await _userRepository.GetAllAsync());
    }
}
