using Officely.StorageService.Domain.Enums;
using RB.SharedKernel;

namespace Officely.StorageService.Domain.Entities;

public class StorageItem : Entity<Guid>
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; } // Nullable to allow root items without a parent
    public Guid AuthorId { get; set; }
    public StorageItemType Type { get; set; }

    private StorageItem(Guid id, string name, Guid? parentId, Guid authorId, StorageItemType type) : base(id)
    {
        ParentId = parentId;
        AuthorId = authorId;
        Name = name;
        Type = type;
    }

    public static StorageItem Initialize(Guid id, string name, Guid? parentId, Guid authorId, StorageItemType type)
        => new(id, name, parentId, authorId, type);

    public static StorageItem CreateCustomerDirectory(Guid authorId)
        => new(Guid.NewGuid(), authorId.ToString().ToUpper(), null, authorId, StorageItemType.Directory);
}
