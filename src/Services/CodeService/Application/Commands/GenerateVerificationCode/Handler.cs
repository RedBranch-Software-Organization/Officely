using RB.SharedKernel.MediatR.Command;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
namespace Application.Commands.GenerateVerificationCode;

public class Handler(ICodeService codeService) : ICommandHandler<Command, Response>
{
    private readonly ICodeService _codeService = codeService;

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        => new Response((await _codeService.GenerateAsync(CodeType.FromValue(request.CodeType), cancellationToken)).Value);
}