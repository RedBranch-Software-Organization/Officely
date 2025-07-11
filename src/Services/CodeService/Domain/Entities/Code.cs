using RB.SharedKernel;

namespace RB.Storage.CodeService.Domain.Entities;

public class Code(string code) : ValueObject
{
    public string Value { get; private set; } = code;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
