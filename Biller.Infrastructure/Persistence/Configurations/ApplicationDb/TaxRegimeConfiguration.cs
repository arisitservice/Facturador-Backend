using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biller.Domain.Entities.TenantsContext;

namespace Biller.Infrastructure.Persistence.Configurations.ApplicationDb;

public class TaxRegimeConfiguration : IEntityTypeConfiguration<TaxRegime>
{
    public void Configure(EntityTypeBuilder<TaxRegime> builder)
    {
        builder.ToTable("TaxRegimes").HasKey(r => r.Id);

        builder.Property(r => r.SatCode);
        builder.Property(r => r.Description).HasMaxLength(200);
        builder.Property(r => r.Status);
    }
}
