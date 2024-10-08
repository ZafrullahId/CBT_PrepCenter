using CBTPreparation.Domain.AdminAggregate;
using CBTPreparation.Domain.FreeQuestionAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    internal class FreeQuestionsConfiguration : IEntityTypeConfiguration<FreeQuestion>
    {
        public void Configure(EntityTypeBuilder<FreeQuestion> builder)
        {
            builder.ToTable(CBTDbContextSchema.FreeQuestionDbSchema.TableName);

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => FreeQuestionId.Create(value));

            builder.Property(x => x.SubjectName)
                .IsRequired();

            builder.Property(x => x.ExamType)
                .IsRequired(false);

            builder.Property(x => x.ExamYear)
                .IsRequired(false);

            builder.Property(x => x.ImageUrl)
                .IsRequired(false);

            builder.OwnsMany(x => x.FreeOptions, fo =>
            {
                fo.ToTable(CBTDbContextSchema.FreeQuestionDbSchema.FreeOptionTableName);

                fo.WithOwner()
                .HasForeignKey(x => x.FreeQuestionId);

                fo.Property(x => x.OptionContent)
                    .IsRequired();

                fo.Property(x => x.OptionAlpha)
                .IsRequired(true);

                fo.Property(x => x.IsCorrect)
                .IsRequired(true);

                fo.Property(x => x.ImageUrl)
                .IsRequired(false);

            });

            builder.Navigation(x => x.FreeOptions)
                .Metadata.SetField(CBTDbContextSchema.FreeQuestionDbSchema.FreeOptionBackendField);
        }
    }
}
