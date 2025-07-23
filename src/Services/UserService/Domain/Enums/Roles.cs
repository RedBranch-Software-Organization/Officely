using Ardalis.SmartEnum;

namespace Officely.UserService.Domain.Enums;

public sealed class Roles : SmartFlagEnum<Roles, int>
{
    public static readonly Roles Client = new(nameof(Client), 1);
    public static readonly Roles Admin = new(nameof(Admin), 2);

    private Roles(string name, int value) : base(name, value)
    {
    }

}
