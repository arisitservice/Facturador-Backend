using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities.Tenant;

namespace Biller.Infrastructure.Persistence.Configurations.TenantDb;

public class ClientTaxInfoConfiguration : IEntityTypeConfiguration<ClientTaxInfo>
{
    public void Configure(EntityTypeBuilder<ClientTaxInfo> builder)
    {
        builder.ToTable("ClientTaxInfos").HasKey(t => t.Id);

        builder.Property(r => r.TaxAddress).HasMaxLength(500).IsRequired();
        builder.Property(r => r.PostalCode).HasMaxLength(5).IsRequired();
        builder.Property(r => r.BusinessName).HasMaxLength(200).IsRequired();
        builder.Property(r => r.TaxId).HasMaxLength(50).IsRequired();

        builder.Property(u => u.Created);
        builder.Property(u => u.CreatedBy).HasMaxLength(256);
        builder.Property(u => u.LastModified);
        builder.Property(u => u.LastModifiedBy).HasMaxLength(256);

        builder.HasOne(r => r.TaxRegime)
            .WithMany(rf => rf.ClientTaxInfos)
            .HasForeignKey(ct => ct.TaxRegimeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Client)
            .WithMany(rf => rf.ClientTaxInfos)
            .HasForeignKey(ct => ct.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
