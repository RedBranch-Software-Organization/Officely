using Officely.UserService.Domain.Entities;
using Officely.UserService.Domain.Enums;
using Officely.UserService.Domain.ValueObjects;
using Officely.UserService.Infrastructure.Databases.Officely.Documents;

namespace Officely.UserService.Infrastructure.Databases.Officely.Mappers;
internal static class UserMapper
{
    public static User MapToDomain(UserDocument user)
    {
        _ = Guid.TryParse(user.Id, out var userId);
        return User.Initialize(
              userId
            , Email.Initialize(user.Email)
            , Username.Initialize(user.Username)
            , PasswordHash.Initialize(user.PasswordHash)
            , user.CreatedAt
            , Roles.FromValue(user.Roles).First(r => r.Value.Equals(user.Roles))
            , VerificationCode.Initialize(user.VerificationCode, user.VerificationCodeExpiresAt
            , user.VerifiedAt)
            );
    }

    public static UserDocument MapToDocument(User user)
        => new()
        {
            Id = user.Id.ToString().ToLower(),
            Email = user.Email.Value,
            PasswordHash = user.PasswordHash.Value,
            Username = user.Username.Value,
            CreatedAt = user.CreatedAt,
            Roles = user.Roles.Value,
            VerificationCode = user.VerificationCode.Value,
            VerificationCodeExpiresAt = user.VerificationCode.VerificationCodeExpiresAt,
            VerifiedAt = user.VerificationCode.VerifiedAt
        };
}
