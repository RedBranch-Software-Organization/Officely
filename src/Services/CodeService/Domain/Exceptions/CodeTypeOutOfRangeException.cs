using Officely.CodeService.Domain.Enums;

namespace Officely.CodeService.Domain.Exceptions;
public class CodeTypeOutOfRangeException(int codeType) 
    : Exception($"Code type '{codeType}' is out of range. Valid code types are between {CodeType.MinValue} and {CodeType.MaxValue}.") { }
