using Officely.StorageService.Domain.Enums;
using RB.SharedKernel;

namespace Officely.StorageService.Domain.Entities;

public class StorageItem : Entity<Guid>
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; } // Nullable to allow root items without a parent
    public Guid AuthorId { get; set; }
    public StorageItemType Type { get; set; }

    private readonly List<StorageItem> _children;
    public IReadOnlyCollection<StorageItem> Children => _children.AsReadOnly();

    private StorageItem(Guid id, string name, Guid? parentId, Guid authorId, StorageItemType type, List<StorageItem> children) : base(id)
    {
        ParentId = parentId;
        AuthorId = authorId;
        Name = name;
        Type = type;
        _children = children;
    }

    public static StorageItem Initialize(Guid id, string name, Guid? parentId, Guid authorId, StorageItemType type, List<StorageItem> children)
        => new(id, name, parentId, authorId, type, children);

    public static StorageItem CreateClientDirectory(Guid authorId)
        => new(Guid.NewGuid(), authorId.ToString().ToUpper(), null, authorId, StorageItemType.Directory, []);
}
