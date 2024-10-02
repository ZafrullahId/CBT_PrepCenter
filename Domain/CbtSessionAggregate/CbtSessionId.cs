using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.CbtSessionAggregate
{
    public sealed class CbtSessionId : ValueObject<CbtSessionId>
    {
        public Guid Value { get; init; }
        public CbtSessionId(Guid value)
        {
            Value = value;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static CbtSessionId CreateUniqueId() => Create(Guid.NewGuid());

        private static CbtSessionId Create(Guid value) => new(value);
    }
}
