using Officely.UserService.Domain.ValueObjects;

namespace Officely.UserService.Domain.Interfaces;

public interface IPasswordService
{
    HashedPassword Hash(Password password);
    PasswordVerifyResult Verify(Password password, HashedPassword hashedPassword);
}
