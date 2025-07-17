using RB.SharedKernel.MediatR.Command;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Exceptions;
using RB.Storage.CodeService.Domain.Interfaces;
using RB.Storage.CodeService.Domain.ValueObjects;
using RB.Storage.CodeService.Application.Commands.GenerateCode;
using MediatR;

namespace RB.Storage.CodeService.Application.Commands.GenerateCode;

internal class Handler(IGeneratorFactory generatorFactory) : ICommandHandler<Command, Result>
{
    //ToDo: Change Handle to HandleAsync when RB.SharedKernel.MediatR is updated to support async handlers
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        if (!CodeType.TryFromValue(request.CodeType!.Value, out var codeType)) 
            throw new CodeTypeOutOfRangeException(request.CodeType!.Value);

        List<string> result = [];
        for (int i = 0; i < request.Quantity!.Value; i++)
            result.Add((await Code.GenerateAsync(codeType, generatorFactory)).Value);
        return new Result(result);
    }
}