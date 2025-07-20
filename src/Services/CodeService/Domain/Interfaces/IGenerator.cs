using Officely.CodeService.Domain.Enums;
using Officely.CodeService.Domain.ValueObjects;

namespace Officely.CodeService.Domain.Interfaces;

public interface IGenerator
{
    CodeType CodeType { get; }
    Task<string> GenerateAsync(CancellationToken cancellationToken = default);
}
