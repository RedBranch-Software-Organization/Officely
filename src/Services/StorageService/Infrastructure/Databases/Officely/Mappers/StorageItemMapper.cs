using Officely.StorageService.Domain.Entities;
using Officely.StorageService.Domain.Enums;
using Officely.StorageService.Infrastructure.Databases.Officely.Documents;

namespace Officely.StorageService.Infrastructure.Databases.Officely.Mappers;

public static class StorageItemMapper
{
    public static StorageItemDocument MapToDocument(StorageItem storageItem)
    {
        if (storageItem == null) throw new ArgumentNullException(nameof(storageItem));

        return new StorageItemDocument
        {
            Id = storageItem.Id.ToString(),
            Name = storageItem.Name,
            AuthorId = storageItem.AuthorId.ToString(),
            Type = storageItem.Type,
            Children = [.. storageItem.Children.Select(MapToDocument)],
        };
    }

    public static StorageItem MapToDomain(StorageItemDocument document) => document == null
            ? throw new ArgumentNullException(nameof(document))
            : StorageItem.Initialize(Guid.Parse(document.Id),
            document.Name,
            null,
            Guid.Parse(document.AuthorId),
            StorageItemType.FromValue(document.Type),
            [.. document.Children.Select(MapToDomain)]);
}
