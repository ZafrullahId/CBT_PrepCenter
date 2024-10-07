using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.StudentAggregate
{
    public class Course : ValueObject<Course>
    {
        public string Name { get; init; }
        private Course(string name)
        {
            Name = name;
        }
        public Course()
        {
            
        }
        public static Course Create(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            return new(name);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
