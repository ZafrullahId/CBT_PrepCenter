using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.AdminAggregate
{
    public class AdminId : ValueObject<AdminId>
    {
        public Guid Value { get; init; }
        public AdminId(Guid id)
        {
            Value = id;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static AdminId CreateUniqueId() => Create(Guid.NewGuid());

        public static AdminId Create(Guid value) => new(value);
    }
}
