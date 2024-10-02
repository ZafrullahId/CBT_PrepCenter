using CBTPreparation.Domain.Entity;

namespace CBTPreparation.BuildingBlocks.Domain.Exceptions
{
    public class InvalidRoleNameException : DomainException
    {
        private const string _messages = "Invalid Role Name `{0}`.";
        public InvalidRoleNameException(string name) : base(string.Format(_messages, name))
        {
        }
        public static void Throw(string name)
        {
            if (!name.Equals(Constant.AdminRole) && !name.Equals(Constant.StudentRole))
                throw new InvalidRoleNameException(name);
        }
    }
}
