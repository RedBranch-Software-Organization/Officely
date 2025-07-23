using Officely.UserService.Domain.ValueObjects;

namespace Officely.UserService.Domain.Interfaces;

public interface IPasswordService
{
    PasswordHash Hash(Password password);
    PasswordVerifyResult Verify(Password password, PasswordHash hashedPassword);
}
