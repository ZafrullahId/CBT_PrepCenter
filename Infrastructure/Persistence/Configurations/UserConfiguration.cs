using CBTPreparation.Domain.UserAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(CBTDbContextSchema.UserDbSchema.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => UserId.Create(value));

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(1044)
                .IsUnicode(true);

            builder.OwnsOne(x => x.Role, rl =>
            {
                rl.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(CBTDbContextSchema.UserDbSchema.RoleName);
            });
        }
    }
}
