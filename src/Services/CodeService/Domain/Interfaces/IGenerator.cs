using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.Interfaces;

public interface IGenerator
{
    CodeType CodeType { get; }
    Task<string> GenerateAsync(CancellationToken cancellationToken = default);
}
