using RB.SharedKernel.MediatR.Command;
using RB.Storage.CodeService.Domain.Entities;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
namespace Application.Commands.GenerateVerificationCode;

public class GenerateVerificationCodeCommandHandler(ICodeService codeService) : ICommandHandler<GenerateVerificationCodeCommand, GenerateVerificationCodeCommandResponse>
{
    private readonly ICodeService _codeService = codeService;

    public async Task<GenerateVerificationCodeCommandResponse> Handle(GenerateVerificationCodeCommand request, CancellationToken cancellationToken)
        => new GenerateVerificationCodeCommandResponse((await _codeService.GenerateAsync(CodeType.FromValue(request.CodeType), cancellationToken)).Value);
}