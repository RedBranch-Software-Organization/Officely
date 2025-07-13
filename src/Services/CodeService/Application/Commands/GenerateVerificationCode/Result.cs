using RB.SharedKernel.MediatR.Command;
namespace Application.Commands.GenerateVerificationCode;

public record Result(string VerificationCode) : ICommandResult;