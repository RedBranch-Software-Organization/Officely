using Officely.UserService.Application.Models.SignUp;
using RB.SharedKernel.MediatR.Command;

namespace Officely.UserService.Application.Commands.SignUp;

public record Result(User User) : ICommandResult;
