using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.CbtSessionAggregate
{
    public class SessionQuestionId : ValueObject<SessionQuestionId>
    {
        public Guid Value { get; init; }
        public SessionQuestionId(Guid value)
        {
            Value = value;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static SessionQuestionId CreateUniqueId() => Create(Guid.NewGuid());

        public static SessionQuestionId Create(Guid value) => new(value);
    }
}
