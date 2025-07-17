using RB.SharedKernel;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;

namespace RB.Storage.CodeService.Domain.ValueObjects;

public class Code : ValueObject<string>
{
    public CodeType CodeType { get; }
    public override string Value { get; }

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
