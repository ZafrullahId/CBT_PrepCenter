using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.UserAggregate
{
    public class UserId : ValueObject<UserId>
    {
        public Guid Value { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static UserId CreateUniqueId() => Create(Guid.NewGuid());

        public static UserId Create(Guid value) => new UserId { Value = value };
    }
}
