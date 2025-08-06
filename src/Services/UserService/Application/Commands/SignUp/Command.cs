using RB.SharedKernel.MediatR.Command;

namespace Officely.UserService.Application.Commands.SignUp;

public record Command(string Email, string Password, string Username) : ICommand<Result>;