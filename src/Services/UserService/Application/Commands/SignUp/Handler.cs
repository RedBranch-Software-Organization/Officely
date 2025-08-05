using Officely.UserService.Domain.Entities;
using Officely.UserService.Domain.Interfaces;
using SignUpUser = Officely.UserService.Application.Models.SignUp.User;
using RB.SharedKernel.MediatR.Command;

namespace Officely.UserService.Application.Commands.SignUp;

public class Handler(IUserRepository userRepository, IPasswordService passwordService, IVerificationCodeGenerator verificationCodeGenerator) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await User.CreateClientAsync(request.Email, request.Username, request.Password, passwordService, verificationCodeGenerator);
        var addedUser = await userRepository.AddAsync(user);
        return new(new SignUpUser()
        {
            Id = addedUser.Id,
            Email = addedUser.Email.Value,
            VerificationCode = addedUser.VerificationCode.Value
        });
    }
}
