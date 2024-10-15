using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.StudentAggregate
{
    public sealed class StudentId : ValueObject<StudentId>
    {
        public Guid Value { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static StudentId CreateUniqueId() => Create(Guid.NewGuid());

        public static StudentId Create(Guid value) => new StudentId { Value = value };
    }
}
