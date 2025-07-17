using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
using RB.Storage.CodeService.Domain.Services;

namespace RB.Storage.CodeService.Domain.Factories;

public class GeneratorFactory : IGeneratorFactory
{
    public IGenerator Create(CodeType codeType)
    {
        return codeType switch
        {
            _ when codeType.Equals(CodeType.Verification) => new VerificationCodeGenerator(),
            _ => throw new NotSupportedException($"Code type '{codeType.Name}' is not supported.")
        };
    }
}
