using RB.Storage.CodeService.Domain.Enums;

namespace RB.Storage.CodeService.Domain.Interfaces;

public interface IGeneratorFactory
{
    IGenerator Create(CodeType codeType);
}
