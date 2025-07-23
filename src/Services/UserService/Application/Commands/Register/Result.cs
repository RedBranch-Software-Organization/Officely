using Officely.UserService.Domain.Entities;
using RB.SharedKernel.MediatR.Command;

namespace Officely.UserService.Application.Commands.Register;

public record Result(User User) : ICommandResult;
