using Biller.Domain.Entities.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class TaxInfoBaseConfiguration : IEntityTypeConfiguration<TaxInfoBase>
{
    public void Configure(EntityTypeBuilder<TaxInfoBase> builder)
    {
        builder.UseTptMappingStrategy();
        builder.ToTable("TaxInfoBases").HasKey(t => t.Id);

        builder.Property(r => r.TaxAddress).HasMaxLength(500).IsRequired();
        builder.Property(r => r.PostalCode).HasMaxLength(5).IsRequired();
        builder.Property(r => r.BusinessName).HasMaxLength(200).IsRequired();
        builder.Property(r => r.TaxId).HasMaxLength(50).IsRequired();

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);

        builder.HasOne(r => r.TaxRegime)
            .WithMany(rf => rf.TaxInfoBases)
            .HasForeignKey(t => t.TaxRegimeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
