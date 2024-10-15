﻿using CBTPreparation.Domain.CbtSessionAggregate;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    internal class CbtSessionConfiguration : IEntityTypeConfiguration<CbtSession>
    {
        public void Configure(EntityTypeBuilder<CbtSession> builder)
        {
            builder.ToTable(CBTDbContextSchema.CbtSessionDbSchema.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(
                    id => id.Value,
                    value => CbtSessionId.Create(value));

            builder.Property(x => x.NumberOfQuestion)
                .IsRequired();

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.Property(x => x.NumberOfQuestionAttempted)
                .IsRequired();

            builder.Property(x => x.NumberOfQuestionAttempted)
                .IsRequired();

            builder.Property(x => x.InProgress)
                .IsRequired();

            //builder.HasOne<Student>()
            //    .WithMany()
            //    .HasForeignKey(x => x.StudentId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(x => x.StudentId, st =>
            {
                st.Property(c => c.Value)
                .IsRequired()
                .HasColumnName(CBTDbContextSchema.StudentDbSchema.ForeignKey);
            });

            builder.OwnsMany(x => x.SessionQuestions, cb =>
            {
                cb.ToTable(CBTDbContextSchema.CbtSessionDbSchema.SessionQuestionTableName);

                cb.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .HasConversion(id => id.Value,
                                  value => SessionQuestionId.Create(value));

                cb.HasKey(x => x.Id);

                cb.WithOwner()
               .HasForeignKey(x => x.CbtSessionId);

                cb.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired()
                .HasConversion(id => id.Value,
                                value => SessionQuestionId.Create(value));

                cb.Property(x => x.ChosenOption)
                .IsRequired(false);

                cb.Property(x => x.IsChosenOptionCorrect)
                .IsRequired();

                cb.Property(x => x.Question)
                .IsRequired()
                .IsUnicode(true);

                cb.OwnsMany(x => x.PaidOptions, pd =>
                {
                    pd.ToTable(CBTDbContextSchema.CbtSessionDbSchema.PaidOptionTableName);

                    pd.WithOwner()
                    .HasForeignKey(x => x.SessionQuestionId);

                    pd.Property(x => x.OptionContent)
                     .IsRequired()
                     .IsUnicode(true);

                    pd.Property(x => x.OptionAlpha)
                    .IsRequired();

                    pd.Property(x => x.ImageUrl)
                    .IsRequired(false);

                    pd.Property(x => x.IsCorrect)
                    .IsRequired();

                }).UsePropertyAccessMode(PropertyAccessMode.Field);

                cb.Navigation(x => x.PaidOptions)
                .Metadata.SetField(CBTDbContextSchema.CbtSessionDbSchema.PaidOptionBackendField);
            });

            builder.Navigation(x => x.SessionQuestions)
                .Metadata.SetField(CBTDbContextSchema.CbtSessionDbSchema.SessionQuestionBackendField);
        }
    }
}
