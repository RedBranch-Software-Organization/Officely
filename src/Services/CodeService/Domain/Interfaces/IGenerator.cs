using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.Interfaces;

internal interface IGenerator
{
    public Task<Code> GenerateAsync(CancellationToken cancellationToken = default);
}
