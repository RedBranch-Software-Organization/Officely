using RB.Storage.CodeService.Domain.Enums;

namespace RB.Storage.CodeService.Domain.Exceptions;
public class CodeTypeOutOfRangeException(int codeType) 
    : Exception($"Code type '{codeType}' is out of range. Valid code types are between {CodeType.MinValue} and {CodeType.MaxValue}.") { }
