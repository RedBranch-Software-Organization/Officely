using Ardalis.SmartEnum;

namespace RB.Storage.CodeService.Domain.Enums;

public sealed class CodeType(string name, int value) : SmartEnum<CodeType>(name, value)
{
    public static readonly CodeType Verification = new(nameof(Verification), 1);
}
