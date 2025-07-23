using Officely.UserService.Domain.ValueObjects;

namespace Officely.UserService.Domain.Interfaces;

public interface IVerificationCodeGenerator
{
    Task<VerificationCode> GenerateAsync();
}
