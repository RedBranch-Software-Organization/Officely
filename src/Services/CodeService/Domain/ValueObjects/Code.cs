using RB.SharedKernel;
using RB.Storage.CodeService.Domain.Enums;

namespace RB.Storage.CodeService.Domain.ValueObjects;

public class Code(string value, CodeType codeType) : ValueObject<Code>
{
    public override Code Value => this;
    public string CodeValue { get; } = value;
    public CodeType CodeType { get; } = codeType;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CodeValue;
        yield return CodeType;
    }
}
