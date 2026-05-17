using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class CfdiPaymentComplementConfiguration : IEntityTypeConfiguration<CfdiPaymentComplement>
{
    public void Configure(EntityTypeBuilder<CfdiPaymentComplement> builder)
    {
        builder.ToTable("CfdiPaymentComplements").HasKey(c => c.Id);

        builder.Property(c => c.OperationNumber).HasMaxLength(100);
        builder.Property(c => c.Series).HasMaxLength(25);
        builder.Property(c => c.ExchangeRate).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.Equivalence).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.PreviousBalanceAmount).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.PaidAmount).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.OutstandingPaidAmount).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.PaymentDate).IsRequired();

        // Integer-based enums → stored as int (default)
        builder.Property(c => c.ApplyTaxes).IsRequired();
        builder.Property(c => c.Status).IsRequired();

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);

        builder.HasOne(c => c.Cfdi)
            .WithMany(c => c.CfdiPaymentComplements)
            .HasForeignKey(c => c.CfdiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Currency)
            .WithMany()
            .HasForeignKey(c => c.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
