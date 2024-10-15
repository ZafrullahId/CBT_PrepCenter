using CBTPreparation.Domain.CourseAggregate;
using CBTPreparation.Domain.FeedbackAggregate;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.TrialTransactionAggregate;
using CBTPreparation.Domain.UserAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(CBTDbContextSchema.StudentDbSchema.TableName);

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => StudentId.Create(value));

            builder.Property(x => x.UnusedTrials)
                .IsRequired();

            //builder.HasOne<User>()
            //  .WithOne()
            //  .HasForeignKey<Student>(x => x.UserId)
            //  .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(x => x.UserId, us =>
            {
                us.Property(x => x.Value)
                .IsRequired()
                .HasColumnName(CBTDbContextSchema.UserDbSchema.ForeignKey);
            });

            builder.OwnsOne(x => x.Department, dp =>
            {
                dp.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode()
                .HasColumnName(CBTDbContextSchema.StudentDbSchema.DepartmentName);
            });
                            
            builder.OwnsMany(x => x.CoursesIds, cr =>
            {
                cr.ToTable(CBTDbContextSchema.StudentDbSchema.CourseIdsTableName);

                cr.Property(x => x.Value)
               .HasColumnName(CBTDbContextSchema.CourseDbSchema.ForeignKey);

            }).UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(x => x.CoursesIds)
                .Metadata.SetField(CBTDbContextSchema.StudentDbSchema.CourseBackendField);

            builder.OwnsMany(x => x.FeedbackIds, fb =>
            {
                fb.ToTable(CBTDbContextSchema.StudentDbSchema.FeedBackIdTableName);

                fb.Property(x => x.Value)
                .HasColumnName(CBTDbContextSchema.FeedbackDbSchema.ForeignKey);

            }).UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(x => x.FeedbackIds)
                .Metadata.SetField(CBTDbContextSchema.StudentDbSchema.FeedbacksBackendField);

            builder.OwnsMany(x => x.TrialTransactionIds, txn =>
            {
                txn.ToTable(CBTDbContextSchema.StudentDbSchema.TrialTransactionIdTableName);

                txn.Property(x => x.Value)
                .HasColumnName(CBTDbContextSchema.TrialTransactionDbSchema.ForeignKey);

            }).UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(x => x.TrialTransactionIds)
                .Metadata.SetField(CBTDbContextSchema.StudentDbSchema.TrialTransactionBackendField);
        }

    }
}
