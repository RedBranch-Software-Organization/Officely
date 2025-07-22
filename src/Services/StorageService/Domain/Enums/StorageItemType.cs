using Ardalis.SmartEnum;

namespace Officely.StorageService.Domain.Enums;
internal class StorageItemType(string name, int value) : SmartEnum<StorageItemType>(name, value)
{
    public static readonly StorageItemType File = new(nameof(File), 1);
    public static readonly StorageItemType Directory = new(nameof(Directory), 2);
}
