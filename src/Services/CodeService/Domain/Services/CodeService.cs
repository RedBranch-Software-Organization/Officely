using RB.Storage.CodeService.Domain.Entities;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;

namespace RB.Storage.CodeService.Domain.Services;

internal class CodeService : ICodeService
{
    //ToDo: Move to a factory
    public async Task<Code> GenerateAsync(CodeType generatorType, CancellationToken cancellationToken = default)
        => await ((IGenerator)(generatorType switch
        {
            _ when CodeType.Verification.Equals(generatorType) => new VerifyGenerator(),
            _ => throw new ArgumentOutOfRangeException(nameof(generatorType), generatorType, null)
        })).GenerateAsync(cancellationToken);
}
