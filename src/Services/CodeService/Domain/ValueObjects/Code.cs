using RB.SharedKernel;

namespace RB.Storage.CodeService.Domain.ValueObjects;

public class Code(string value) : ValueObject<string>
{
    public override string Value => value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
