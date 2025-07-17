using RB.SharedKernel.MediatR.Command;
namespace RB.Storage.CodeService.Application.Commands.GenerateCode;

internal record Result(List<string> Codes) : ICommandResult;