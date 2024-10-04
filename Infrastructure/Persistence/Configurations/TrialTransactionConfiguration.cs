using CBTPreparation.Domain.TrialTransactionAggregate;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBTPreparation.Infrastructure.Persistence.Configurations
{
    internal class TrialTransactionConfiguration : IEntityTypeConfiguration<TrialTransaction>
    {
        public void Configure(EntityTypeBuilder<TrialTransaction> builder)
        {
            builder.ToTable(CBTDbContextSchema.TralTransactionDbSchema.TableName);


            builder.HasKey(t => t.Id);

            builder.Property(x => x.PurchaseDate)
                .IsRequired();

            builder.Property(x => x.TrialPrice)
                .IsRequired();
            
            builder.Property(x => x.TotalAmount)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .IsRequired()
                .IsUnicode();

            builder.OwnsOne(x => x.StudentId, st =>
            {
                st.Property(x => x.Value)
                .IsRequired();
            });
        }
    }
}
