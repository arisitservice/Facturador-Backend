using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class CfdiConceptConfiguration : IEntityTypeConfiguration<CfdiConcept>
{
    public void Configure(EntityTypeBuilder<CfdiConcept> builder)
    {
        builder.ToTable("CfdiConcepts").HasKey(c => c.Id);

        builder.Property(c => c.Description).HasMaxLength(1000).IsRequired();
        builder.Property(c => c.Quantity).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.UnitPrice).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.Amount).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.TaxTransfer).HasPrecision(18, 6).IsRequired();

        // Integer-based enum → stored as int (default)
        builder.Property(c => c.Status).IsRequired();

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);

        builder.HasOne(c => c.Cfdi)
            .WithMany(c => c.CfdiConcepts)
            .HasForeignKey(c => c.CfdiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.MeasurementUnit)
            .WithMany()
            .HasForeignKey(c => c.MeasurementUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Product)
            .WithMany()
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
