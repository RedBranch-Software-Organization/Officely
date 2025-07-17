using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.Services;

internal class CodeService(IGeneratorFactory generatorFactory) : ICodeService
{
    public async Task<Code> GenerateAsync(CodeType generatorType, CancellationToken cancellationToken = default)
    {
        var generator = generatorFactory.Create(generatorType);
        return await generator.GenerateAsync(cancellationToken);
    }
}
