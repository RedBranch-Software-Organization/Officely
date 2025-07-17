using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;
using System.Text;

namespace RB.Storage.CodeService.Domain.Services.Generators;
internal class DefaultCodeGenerator : IGenerator
{
    public CodeType CodeType => CodeType.Default;

    private readonly char[] _allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=[]{}|:;,.<>?".ToCharArray();
    private readonly int _minValue = 1;
    private readonly int _maxValue = 100;
    private int AllowedCharsLength => _allowedChars.Length;

    public async Task<string> GenerateAsync(CancellationToken cancellationToken = default)
    {
        Random random = new();
        StringBuilder sb = new();
        var length = random.Next(_minValue, _maxValue + 1); // Random length between 1 and 100
        for (int i = 0; i < length; i++)
            sb.Append(_allowedChars[random.Next(AllowedCharsLength)]);
        return await Task.FromResult(sb.ToString());
    }
}