using CBTPreparation.Domain.AdminAggregate;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.UserAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<User>()
              .WithOne()
              .HasForeignKey<Admin>(x => x.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            //builder.OwnsOne(x => x.UserId, ud =>
            //{
            //    ud.Property(x => x.Value)
            //    .HasColumnName(CBTDbContextSchema.UserDbSchema.ForeignKey);
            //});

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(
                    id => id.Value,
                    value => AdminId.Create(value));
        }
    }
}
