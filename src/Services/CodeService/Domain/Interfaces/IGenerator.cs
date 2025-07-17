using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.Interfaces;

public interface IGenerator
{
    public CodeType CodeType { get; }
    public Task<Code> GenerateAsync(CancellationToken cancellationToken = default);
}
