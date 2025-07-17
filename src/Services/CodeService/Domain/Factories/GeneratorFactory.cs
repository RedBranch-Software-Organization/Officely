using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
using RB.Storage.CodeService.Domain.Services.Generators;

namespace RB.Storage.CodeService.Domain.Factories;

internal class GeneratorFactory : IGeneratorFactory
{
    public IGenerator Create(CodeType codeType)
        => codeType switch
        {
            _ when codeType.Equals(CodeType.Default) => new DefaultCodeGenerator(),
            _ when codeType.Equals(CodeType.Verification) => new VerificationCodeGenerator(),
            _ => throw new NotSupportedException($"Code type '{codeType.Name}' is not supported.")
        };
}
