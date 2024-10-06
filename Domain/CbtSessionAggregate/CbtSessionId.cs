using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.CbtSessionAggregate
{
    public sealed class CbtSessionId : ValueObject<CbtSessionId>
    {
        public Guid Value { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static CbtSessionId CreateUniqueId() => Create(Guid.NewGuid());

        public static CbtSessionId Create(Guid value) => new CbtSessionId { Value = value };
    }
}
