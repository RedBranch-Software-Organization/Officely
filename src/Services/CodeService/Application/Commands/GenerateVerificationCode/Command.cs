using RB.SharedKernel.MediatR.Command;
namespace Application.Commands.GenerateVerificationCode;

public record Command(int CodeType) : ICommand<Response>;