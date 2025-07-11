using System;

namespace Application.Commands.GenerateVerificationCode;

public class GenerateVerificationCodeCommand : IRequest<Code>
{
    public CodeType Type { get; }

    public GenerateVerificationCodeCommand(CodeType type)
    {
        Type = type;
    }
}