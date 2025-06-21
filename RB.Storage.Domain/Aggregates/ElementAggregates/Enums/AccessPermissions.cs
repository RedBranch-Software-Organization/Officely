using Ardalis.SmartEnum;

namespace RB.Storage.Domain.Aggregates.ElementAggregates.Enums;

public class AccessPermissions(string name, int value) : SmartFlagEnum<AccessPermissions>(name, value)
{
    public static readonly AccessPermissions None = new(nameof(None), 0);
    public static readonly AccessPermissions View = new(nameof(View), 1);
    public static readonly AccessPermissions Modify = new(nameof(Modify), 2);
    public static readonly AccessPermissions Delete = new(nameof(Delete), 4);
    public static readonly AccessPermissions All = new(nameof(All), 7); // 1 | 2 | 4
}
