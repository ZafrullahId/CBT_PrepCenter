namespace CBTPreparation.BuildingBlocks.Domain
{
    public class AuditableEntity : IAuditableEntity, ISoftDelete
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public Guid LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
