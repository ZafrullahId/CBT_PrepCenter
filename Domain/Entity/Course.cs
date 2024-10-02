using CBTPreparation.BuildingBlocks.Domain;

namespace Domain.Entity
{
    public class Course : ValueObject<Course>
    {
        public string Name { get; init; }
        public Course(string name)
        {
            Name = name;
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
