using RB.Storage.CodeService.Domain.Entities;

namespace RB.Storage.CodeService.Domain.Interfaces;

public interface IGenerator
{
    public Task<Code> GenerateAsync();
}
