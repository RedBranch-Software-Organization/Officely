using RB.SharedKernel;
using RB.Storage.CodeService.Domain.Entities;
using RB.Storage.CodeService.Domain.Interfaces;

namespace RB.Storage.CodeService.Domain.Services;

internal class VerifyGenerator : IGenerator, IAggregateRoot
{
    public async Task<Code> GenerateAsync()
    {
        var code = string.Empty;
        for (int i = 0; i < 6; i++)
        {
            var randomDigit = new Random().Next(10);
            code += randomDigit.ToString();
        }
        return await Task.FromResult(new Code(code));
    }
}
