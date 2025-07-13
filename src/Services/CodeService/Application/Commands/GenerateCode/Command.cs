using RB.SharedKernel.MediatR.Command;
namespace Application.Commands.GenerateCode;

public record Command(int CodeType) : ICommand<Result>;