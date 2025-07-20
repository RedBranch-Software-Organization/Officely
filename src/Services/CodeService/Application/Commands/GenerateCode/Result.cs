using RB.SharedKernel.MediatR.Command;
namespace Officely.CodeService.Application.Commands.GenerateCode;

internal record Result(List<string> Codes) : ICommandResult;