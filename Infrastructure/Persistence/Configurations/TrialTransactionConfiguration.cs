//using CBTPreparation.Domain.StudentAggregate;
//using CBTPreparation.Infrastructure.Persistence.Context;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace CBTPreparation.Infrastructure.Persistence.Configurations
//{
//    internal class TrialTransactionConfiguration : IEntityTypeConfiguration<TrialTransaction>
//    {
//        public void Configure(EntityTypeBuilder<TrialTransaction> builder)
//        {
//            builder.ToTable(CBTDbContextSchema.TrialTransactionDbSchema.TableName);

//            builder.HasKey(t => t.Id);

//            builder.Property(x => x.Id)
//               .ValueGeneratedNever()
//               .HasConversion(id => id.Value,
//                  value => TrialTransactionId.Create(value));

//            builder.Property(x => x.PurchaseDate)
//                .IsRequired();

//            builder.Property(x => x.TrialPrice)
//                .IsRequired();

//            builder.Property(p => p.TotalAmount)
//                .HasField(CBTDbContextSchema.TrialTransactionDbSchema.TotalAmountBackendField)
//                .UsePropertyAccessMode(PropertyAccessMode.Field);

//            builder.Property(x => x.Quantity)
//                .IsRequired();

//            builder.Property(x => x.PaymentMethod)
//                .IsRequired()
//                .IsUnicode();

//            builder.OwnsOne(x => x.StudentId, st =>
//            {
//                st.Property(x => x.Value)
//                .IsRequired();
//            });
//        }
//    }
//}
