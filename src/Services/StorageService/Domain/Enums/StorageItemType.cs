using Ardalis.SmartEnum;

namespace Officely.StorageService.Domain.Enums;
public sealed class StorageItemType(string name, int value) : SmartEnum<StorageItemType>(name, value)
{
    public static readonly StorageItemType File = new(nameof(File), 1);
    public static readonly StorageItemType Directory = new(nameof(Directory), 2);
}
