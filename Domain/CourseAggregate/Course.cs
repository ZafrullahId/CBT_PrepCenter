using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.CourseAggregate
{
    public class Course(CourseId id) : AggregateRoot<CourseId>(id)
    {
        public Course() : this(null!) { }
        public string Name { get; init; }
        public static Course Create(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

            return new Course(CourseId.CreateUniqueId())
            {
                Name = name,
            };
        }
    }
}
