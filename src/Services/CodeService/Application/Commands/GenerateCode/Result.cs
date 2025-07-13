using RB.SharedKernel.MediatR.Command;
namespace Application.Commands.GenerateCode;

public record Result(string Code) : ICommandResult;