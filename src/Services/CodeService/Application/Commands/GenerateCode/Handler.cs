using RB.SharedKernel.MediatR.Command;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;

namespace Application.Commands.GenerateCode;

public class Handler(ICodeService codeService) : ICommandHandler<Command, Result>
{
    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        var code = await codeService.GenerateAsync(CodeType.FromValue(request.CodeType), cancellationToken);
        return new Result(code.CodeValue);
    }
}