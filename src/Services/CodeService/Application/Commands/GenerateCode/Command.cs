using RB.SharedKernel.MediatR.Command;
namespace RB.Storage.CodeService.Application.Commands.GenerateCode;

internal record Command(int? CodeType = 0, int? Quantity = 1) : ICommand<Result>;