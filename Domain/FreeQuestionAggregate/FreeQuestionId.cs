using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.FreeQuestionAggregate
{
    public class FreeQuestionId : ValueObject<FreeQuestionId>
    {
        public Guid Value { get; init; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static FreeQuestionId CreateUniqueId() => Create(Guid.NewGuid());

        public static FreeQuestionId Create(Guid value) => new FreeQuestionId { Value = value };
    }
}
