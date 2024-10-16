using CBTPreparation.Domain.CourseAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(CBTDbContextSchema.CourseDbSchema.TableName);

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                  value => CourseId.Create(value));

            builder.Property(x => x.Name)
                .IsRequired();

            
        }
    }
}
