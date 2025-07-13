using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.Interfaces;

public interface ICodeService
{
    public Task<Code> GenerateAsync(CodeType type, CancellationToken cancellationToken = default);
}
