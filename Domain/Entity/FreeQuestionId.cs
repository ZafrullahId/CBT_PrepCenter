using CBTPreparation.BuildingBlocks.Domain;

namespace Domain.Entity
{
    public class FreeQuestionId : ValueObject<FreeQuestionId>
    {
        public Guid Value { get; init; }

        public FreeQuestionId(Guid value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static FreeQuestionId CreateUniqueId() => Create(Guid.NewGuid());

        public static FreeQuestionId Create(Guid value) => new(value);
    }
}
