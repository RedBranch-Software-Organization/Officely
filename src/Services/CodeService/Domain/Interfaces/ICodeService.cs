using RB.Storage.CodeService.Domain.Entities;
using RB.Storage.CodeService.Domain.Enums;

namespace RB.Storage.CodeService.Domain.Interfaces;

public interface ICodeService
{
    public Task<Code> GenerateAsync(CodeType type);
}
