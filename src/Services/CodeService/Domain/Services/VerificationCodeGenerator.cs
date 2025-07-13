using System.Text;
using RB.Storage.CodeService.Domain.Interfaces;
using RB.Storage.CodeService.Domain.ValueObjects;

namespace RB.Storage.CodeService.Domain.Services;

internal class VerificationCodeGenerator : IGenerator
{
    public async Task<Code> GenerateAsync(CancellationToken cancellationToken = default)
    {
        Random random = new();
        StringBuilder sb = new();
        for (int i = 0; i < 6; i++)
            sb.Append(random.Next(10));
        return await Task.FromResult(new Code(sb.ToString()));
    }
}
