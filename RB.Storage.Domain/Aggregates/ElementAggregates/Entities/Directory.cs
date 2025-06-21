
namespace RB.Storage.Domain.Aggregates.ElementAggregates.Entities;

public class Directory(Guid id) : IElement
{
    public Guid Id => id;

    public Guid? ParentId => throw new NotImplementedException();

    public string Name => throw new NotImplementedException();

    public string Path => throw new NotImplementedException();

    public Guid CreatedBy => throw new NotImplementedException();

    public DateTime CreatedAt => throw new NotImplementedException();

    public Guid? ModifiedBy => throw new NotImplementedException();

    public DateTime? ModifiedAt => throw new NotImplementedException();

    public IElement Create()
    {
        throw new NotImplementedException();
    }
}
