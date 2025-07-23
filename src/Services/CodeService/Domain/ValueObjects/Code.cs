using RB.SharedKernel;
using Officely.CodeService.Domain.Enums;
using Officely.CodeService.Domain.Interfaces;

namespace Officely.CodeService.Domain.ValueObjects;

public class Code : ValueObject
{
    public string Value { get; }
    public CodeType CodeType { get; }

    private Code(string value, CodeType codeType)
    {
        Value = value;
        CodeType = codeType;
    }

    public static async Task<Code> GenerateAsync(CodeType codeType, IGeneratorFactory generatorFactory)
    {
        var generator = generatorFactory.Create(codeType);
        var value = await generator.GenerateAsync();
        return new Code(value, codeType);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return CodeType;
    }
}
