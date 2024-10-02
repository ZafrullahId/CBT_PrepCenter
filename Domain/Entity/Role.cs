using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.BuildingBlocks.Domain.Exceptions;

namespace CBTPreparation.Domain.Entity
{
    public class Role : ValueObject<Role>
    {
        public string Name { get; init; } = null!;
        internal Role(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
        public static Role Assign(string name)
        {
            InvalidRoleNameException.Throw(name);
            return new Role(name);
        }
    }
}
