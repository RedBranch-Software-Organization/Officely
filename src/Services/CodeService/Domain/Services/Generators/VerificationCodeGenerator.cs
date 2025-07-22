using System.Text;
using Officely.CodeService.Domain.Enums;
using Officely.CodeService.Domain.Interfaces;

namespace Officely.CodeService.Domain.Services.Generators;

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
