using Biller.Domain.Entities.Tenant;
using Biller.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class CfdiConfiguration : IEntityTypeConfiguration<Cfdi>
{
    public void Configure(EntityTypeBuilder<Cfdi> builder)
    {
        builder.ToTable("Cfdis").HasKey(c => c.Id);

        builder.Property(c => c.UUID).HasMaxLength(50);
        builder.Property(c => c.Notes).HasMaxLength(1000);
        builder.Property(c => c.ExchangeRate).HasPrecision(18, 6);

        // ReceiptType: char values ('I','E','P') → stored as string "I","E","P"
        var receiptTypeConverter = new ValueConverter<ReceiptType, string>(
            v => ((char)v).ToString(),
            v => (ReceiptType)v[0]);

        builder.Property(c => c.ReceiptType)
            .HasConversion(receiptTypeConverter)
            .HasMaxLength(1)
            .IsRequired();

        // PaymentMethod: names are SAT codes (PUE / PPD) → stored as string
        builder.Property(c => c.PaymentMethod)
            .HasConversion<string>()
            .HasMaxLength(3)
            .IsRequired();

        // Integer-based enums → stored as int (default)
        builder.Property(c => c.ApplyTaxes).IsRequired();
        builder.Property(c => c.Status).IsRequired();
        builder.Property(c => c.StampingStatus).IsRequired();
        builder.Property(c => c.PaymentStatus).IsRequired();

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);

        builder.HasOne(c => c.Issuer)
            .WithMany()
            .HasForeignKey(c => c.IssuerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Receiver)
            .WithMany()
            .HasForeignKey(c => c.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.CfdiUse)
            .WithMany()
            .HasForeignKey(c => c.CfdiUseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Currency)
            .WithMany()
            .HasForeignKey(c => c.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
