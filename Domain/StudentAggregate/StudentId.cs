using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.UserAggregate;

namespace CBTPreparation.Domain.StudentAggregate
{
    public sealed class StudentId : ValueObject<UserId>
    {
        public Guid Value { get; init; }
        private StudentId(Guid id)
        {
            Value = id;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static StudentId CreateUniqueId() => Create(Guid.NewGuid());

        public static StudentId Create(Guid value) => new(value);
    }
}
