using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.UserAggregate;

namespace CBTPreparation.Domain.AdminAggregate;

public class Admin : AggregateRoot<AdminId>
{
    public UserId UserId { get; init; }
    private Admin(AdminId id) : base(id)
    {
    }
    private Admin() : this(null!) { }
    public static Admin Create(UserId userId)
    {
        return new Admin(AdminId.CreateUniqueId())
        {
            UserId = userId
        };
    }
}
