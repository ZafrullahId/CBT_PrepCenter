using CBTPreparation.Domain.FeedbackAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable(CBTDbContextSchema.FeedbackDbSchema.TableName);

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                  value => FeedbackId.Create(value));

            builder.Property(x => x.Comment)
                .IsRequired()
                .IsUnicode();

            builder.OwnsOne(x => x.StudentId, st =>
            {
                st.Property(x => x.Value)
                .HasColumnName(CBTDbContextSchema.StudentDbSchema.ForeignKey)
                .IsRequired();
            });

        }
    }
}
