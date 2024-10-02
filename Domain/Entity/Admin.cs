using Blogger.BuildingBlocks.Domain;
using CBTPreparation.Domain.Entity;

namespace Domain.Entity
{
    public class Admin : Entity<AdminId>
    {
        public UserId UserId { get; init; }
        private Admin(AdminId id, UserId userId) : base(id)
        {
            UserId = userId;
        }
        public static Admin Create(UserId userId)
        {
            return new Admin(AdminId.CreateUniqueId(),
                             userId);
        }
    }
}
