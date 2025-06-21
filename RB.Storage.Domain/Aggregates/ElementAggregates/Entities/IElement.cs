namespace RB.Storage.Domain.Aggregates.ElementAggregates.Entities;

public interface IElement
{
    public Guid Id { get; }
    public Guid? ParentId { get; }
    public string Name { get; }
    public string Path { get; }
    public Guid CreatedBy { get; }
    public DateTime CreatedAt { get; }
    public Guid? ModifiedBy { get; }
    public DateTime? ModifiedAt { get; }

    public IElement Create();
}
