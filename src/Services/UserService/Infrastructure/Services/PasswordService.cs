using System;
using Officely.UserService.Domain.Interfaces;
using Officely.UserService.Domain.ValueObjects;

namespace Officely.UserService.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public PasswordHash Hash(Password password)
        => PasswordHash.Initialize(BCrypt.Net.BCrypt.EnhancedHashPassword(password.Value, BCrypt.Net.HashType.SHA512));

    public PasswordVerifyResult Verify(Password password, PasswordHash hashedPassword)
        => PasswordVerifyResult.Initialize(BCrypt.Net.BCrypt.EnhancedVerify(password.Value, hashedPassword.Value, BCrypt.Net.HashType.SHA512));
}
