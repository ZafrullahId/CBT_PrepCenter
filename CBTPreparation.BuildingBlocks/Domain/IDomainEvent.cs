namespace CBTPreparation.BuildingBlocks.Domain;
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
