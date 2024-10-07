﻿using CBTPreparation.Domain.StudentAggregate;
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

            builder.OwnsOne(x => x.Department, dp =>
            {
                dp.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode()
                .HasColumnName(CBTDbContextSchema.StudentDbSchema.DepartmentName);
            });

            builder.OwnsOne(x => x.UserId, ud =>
            {
                ud.Property(x => x.Value)
                .HasColumnName(CBTDbContextSchema.UserDbSchema.ForeignKey);
            });

            builder.OwnsMany(x => x.Courses, cr =>
            {
                cr.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode()
                .HasColumnName(CBTDbContextSchema.StudentDbSchema.CourseName);
            });

            builder.OwnsMany(x => x.Feedbacks, fb =>
            {
                fb.ToTable(CBTDbContextSchema.StudentDbSchema.FeedBackTableName);

                fb.HasKey(x => x.Id);

                fb.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .HasConversion(id => id.Value,
                                  value => FeedbackId.Create(value));

                fb.WithOwner()
                .HasForeignKey(x => x.StudentId);

                fb.Property(x => x.Comment)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(150);
            });

            builder.OwnsMany(x => x.Transactions, txn =>
            {
                txn.ToTable(CBTDbContextSchema.StudentDbSchema.TrialTransactionTableName);

                txn.HasKey(x => x.Id);

                txn.WithOwner()
                  .HasForeignKey(x => x.StudentId);

                txn.Property(x => x.Id)
                       .ValueGeneratedNever()
                       .HasConversion(id => id.Value,
                          value => TrialTransactionId.Create(value));

                txn.Property(x => x.PurchaseDate)
                .IsRequired();

                txn.Property(x => x.TrialPrice)
                    .IsRequired();

                txn.Property(p => p.TotalAmount)
                    .HasField(CBTDbContextSchema.StudentDbSchema.TrialTransactionTotalAmountBackendField)
                    .UsePropertyAccessMode(PropertyAccessMode.Field);

                txn.Property(x => x.Quantity)
                    .IsRequired();

                txn.Property(x => x.PaymentMethod)
                    .IsRequired()
                    .IsUnicode();

            });



        }

    }
}