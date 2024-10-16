using CBTPreparation.Domain.AdminAggregate;
using CBTPreparation.Domain.UserAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable(CBTDbContextSchema.AdminDbSchema.TableName);

            builder.HasKey(x => x.Id);

            //builder.HasOne<User>()
            //  .WithOne()
            //  .HasForeignKey<Admin>(x => x.UserId)
            //  .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(x => x.UserId, us =>
            {
                us.Property(x => x.Value)
                .IsRequired()
                .HasColumnName(CBTDbContextSchema.UserDbSchema.ForeignKey);
            });

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(
                    id => id.Value,
                    value => AdminId.Create(value));
        }
    }
}
