using RB.SharedKernel.MediatR.Command;
using Officely.CodeService.Domain.Enums;
using Officely.CodeService.Domain.Exceptions;
using Officely.CodeService.Domain.Interfaces;
using Officely.CodeService.Domain.ValueObjects;
using Officely.CodeService.Application.Commands.GenerateCode;
using MediatR;

namespace Officely.CodeService.Application.Commands.GenerateCode;

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