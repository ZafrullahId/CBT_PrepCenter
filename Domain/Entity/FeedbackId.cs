using CBTPreparation.BuildingBlocks.Domain;

namespace Domain.Entity
{
    public class FeedbackId : ValueObject<FeedbackId>
    {
        public Guid Value { get; init; }
        public FeedbackId(Guid value)
        {
            Value = value;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static FeedbackId CreateUniqueId() => Create(Guid.NewGuid());

        public static FeedbackId Create(Guid value) => new(value);
    }
}
