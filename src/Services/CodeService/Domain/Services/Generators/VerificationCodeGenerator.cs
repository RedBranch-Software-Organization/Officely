using System.Text;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Interfaces;

namespace RB.Storage.CodeService.Domain.Services.Generators;

public class VerificationCodeGenerator : IGenerator
{
    public CodeType CodeType => CodeType.Verification;
    private const int CodeLength = 6;
    public async Task<string> GenerateAsync(CancellationToken cancellationToken = default)
    {
        Random random = new();
        StringBuilder sb = new();
        for (int i = 0; i < CodeLength; i++)
            sb.Append(random.Next(10));
        return await Task.FromResult(sb.ToString());
    }
}
