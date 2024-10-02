using CBTPreparation.BuildingBlocks.Domain;

namespace Domain.Entity
{
    public class UserId : ValueObject<UserId>
    {
        public Guid Value { get; init; }
        private UserId(Guid id)
        {
            Value = id;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static UserId CreateUniqueId() => Create(Guid.NewGuid());

        public static UserId Create(Guid value) => new(value);
    }
}
