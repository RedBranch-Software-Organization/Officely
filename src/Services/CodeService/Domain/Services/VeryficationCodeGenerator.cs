using System.Text;
using RB.SharedKernel;
using RB.Storage.CodeService.Domain.Entities;
using RB.Storage.CodeService.Domain.Interfaces;

namespace RB.Storage.CodeService.Domain.Services;

internal class VerifyGenerator : IGenerator, IAggregateRoot
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
