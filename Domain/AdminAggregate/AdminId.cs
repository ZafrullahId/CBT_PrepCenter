using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.AdminAggregate
{
    public class AdminId : ValueObject<AdminId>
    {
        public Guid Value { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static AdminId CreateUniqueId() => Create(Guid.NewGuid());

        public static AdminId Create(Guid value) => new AdminId { Value = value };
    }
}
