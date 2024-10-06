using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.StudentAggregate
{
    public class Department : ValueObject<Department>
    {
        public string Name { get; init; }

        public Department(string name)
        {
            Name = name;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
        public static Department Assign(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            return new(name);
        }
    }
}
