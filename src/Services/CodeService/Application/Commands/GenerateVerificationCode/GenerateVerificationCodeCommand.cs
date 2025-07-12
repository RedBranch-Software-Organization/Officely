using RB.SharedKernel.MediatR.Command;
namespace Application.Commands.GenerateVerificationCode;

public record GenerateVerificationCodeCommand(int CodeType) : ICommand<GenerateVerificationCodeCommandResponse>;