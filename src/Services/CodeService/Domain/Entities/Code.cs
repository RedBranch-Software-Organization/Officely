using RB.SharedKernel;

namespace RB.Storage.CodeService.Domain.Entities;

public class Code(string code) : ValueObject<string>
{
    public override string Value => code;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
