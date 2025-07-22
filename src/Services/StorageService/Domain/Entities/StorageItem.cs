using Officely.StorageService.Domain.Enums;
using RB.SharedKernel;

namespace Officely.StorageService.Domain.Entities;
internal class StorageItem(Guid id, Guid authorId, string Name, StorageItemType storageItemType) : Entity<Guid>(id)
{
    public string Name { get; set; } = Name;
    public Guid? ParentId { get; set; } // Nullable to allow root items without a parent
    public Guid AuthorId { get; set; } = authorId;
    public StorageItemType Type { get; set; } = storageItemType;
}
