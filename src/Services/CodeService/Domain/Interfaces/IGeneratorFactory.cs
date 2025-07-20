using Officely.CodeService.Domain.Enums;

namespace Officely.CodeService.Domain.Interfaces;

public interface IGeneratorFactory
{
    IGenerator Create(CodeType codeType);
}
