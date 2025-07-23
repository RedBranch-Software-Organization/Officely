using Officely.UserService.Domain.Entities;
using Officely.UserService.Domain.Interfaces;
using RB.SharedKernel.MediatR.Command;

namespace Officely.UserService.Application.Commands.Register;

public class Handler(IUserRepository userRepository, IPasswordService passwordService, IVerificationCodeGenerator verificationCodeGenerator) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await User.CreateCustomerAsync(request.Email, request.Username, request.Password, passwordService, verificationCodeGenerator);
        var addedUser = await userRepository.AddAsync(user);
        return new(addedUser);
    }
}
