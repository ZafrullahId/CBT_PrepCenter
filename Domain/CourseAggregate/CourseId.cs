using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.CourseAggregate
{
    public class CourseId : ValueObject<CourseId>
    {
        public Guid Value { get; init; }
        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
        public static CourseId CreateUniqueId() => Create(Guid.NewGuid());

        public static CourseId Create(Guid value) => new CourseId { Value = value };
    }
}
