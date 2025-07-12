using RB.SharedKernel.MediatR.Command;
namespace Application.Commands.GenerateVerificationCode;
public record GenerateVerificationCodeCommandResponse(string VerificationCode) : ICommandResponse;