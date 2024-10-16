using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.TrialTransactionAggregate
{
    public class TrialTransactionId : ValueObject<TrialTransactionId>
    {
        public Guid Value { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static TrialTransactionId CreateUniqueId() => Create(Guid.NewGuid());

        public static TrialTransactionId Create(Guid value) => new TrialTransactionId { Value = value };
    }
}
