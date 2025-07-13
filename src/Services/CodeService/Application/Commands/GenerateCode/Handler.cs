using RB.SharedKernel.MediatR.Command;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
namespace Application.Commands.GenerateCode;

public class Handler(ICodeService codeService) : ICommandHandler<Command, Result>
{
    private readonly ICodeService _codeService = codeService;

    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        => new Result((await _codeService.GenerateAsync(CodeType.FromValue(request.CodeType), cancellationToken)).Value);
}