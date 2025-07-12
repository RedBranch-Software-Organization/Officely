using RB.SharedKernel.MediatR.Command;
namespace Application.Commands.GenerateVerificationCode;

public record Response(string VerificationCode) : ICommandResult;