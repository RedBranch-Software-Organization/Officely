using Microsoft.Extensions.Configuration;
using Officely.CodeService.Api.Client;
using Officely.UserService.Domain.Interfaces;
using Officely.UserService.Domain.ValueObjects;

namespace Officely.UserService.Infrastructure.Services;

public class VerificationCodeGenerator(ICodeService codeService, IConfiguration configuration) : IVerificationCodeGenerator
{
    private readonly ICodeService _codeService = codeService;
    private readonly int _codeType = 1; // Assuming 1 is the code type for verification codes
    private readonly int _quantity = 1; // Assuming we want to generate one code at a time
    private readonly int _expirationMinutes = configuration.GetValue<int>("VerificationCodeExpirationMinutes", 1440); // 1 day in minutes

    public async Task<VerificationCode> GenerateAsync()
    {
        var code = await _codeService.GenerateAsync(_codeType, _quantity);

        if (code == null || code.Codes == null || !code.Codes.Any())
            throw new InvalidOperationException("Failed to generate verification code.");

        var verificationCode = code.Codes.FirstOrDefault();
        if (string.IsNullOrEmpty(verificationCode))
            throw new InvalidOperationException("Generated verification code is empty.");

        return VerificationCode.Create(verificationCode, _expirationMinutes);
    }
}
