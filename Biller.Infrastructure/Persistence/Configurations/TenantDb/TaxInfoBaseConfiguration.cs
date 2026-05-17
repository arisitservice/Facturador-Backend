using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class TaxInfoConfiguration : IEntityTypeConfiguration<TaxInfo>
{
    public void Configure(EntityTypeBuilder<TaxInfo> builder)
    {
        builder.ToTable("TaxInfos").HasKey(t => t.Id);

        builder.Property(r => r.TaxAddress).HasMaxLength(500).IsRequired();
        builder.Property(r => r.PostalCode).HasMaxLength(5).IsRequired();
        builder.Property(r => r.BusinessName).HasMaxLength(200).IsRequired();
        builder.Property(r => r.TaxId).HasMaxLength(50).IsRequired();
        builder.Property(r => r.Type).IsRequired();

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);

        builder.HasOne(r => r.TaxRegime)
            .WithMany(rf => rf.TaxInfos)
            .HasForeignKey(t => t.TaxRegimeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Client)
            .WithMany(c => c.TaxInfos)
            .HasForeignKey(t => t.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
